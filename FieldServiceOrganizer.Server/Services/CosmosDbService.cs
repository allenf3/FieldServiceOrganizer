using FieldServiceOrganizer.Models;
using Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<bool> AddAsync(ICosmosItem item)
        {
            var response = await _container.CreateItemAsync(item, new PartitionKey(item.Id));
            return (response.GetRawResponse().Status == 200);
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<ICosmosItem>(id, new PartitionKey(id));
        }

        public async Task<ICosmosItem> GetSingleAsync(string id)
        {
            try
            {
                ItemResponse<ICosmosItem> response = await _container.ReadItemAsync<ICosmosItem>(id, new PartitionKey(id));
                return response.Value;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        //public async Task<IEnumerable<ICosmosItem>> GetAllAsync(string queryString)
        public async Task<IEnumerable<Location>> GetAllAsync(string queryString)

        {
            List<Location> items = new();
            QueryDefinition query = new(queryString);
            var response = _container.GetItemQueryIterator<Location>(query);
            await foreach (var item in response)
            {
                items.Add(item);
            }
            return items;
        }

        public async Task<bool> UpdateAsync(string id, ICosmosItem item)
        {
            var result = await _container.UpsertItemAsync<ICosmosItem>(item, new PartitionKey(id));
            return (result.GetRawResponse().Status == 200);
        }
    }
}
