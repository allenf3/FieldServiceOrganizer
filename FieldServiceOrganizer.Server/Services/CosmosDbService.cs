using FieldServiceOrganizer.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync(ICosmosItem item)
        {
            await _container.CreateItemAsync<ICosmosItem>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<ICosmosItem>(id, new PartitionKey(id));
        }

        public async Task<ICosmosItem> GetSingleAsync(string id)
        {
            try
            {
                ItemResponse<Location> response = await _container.ReadItemAsync<Location>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ICosmosItem>> GetAllAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<ICosmosItem>(new QueryDefinition(queryString));
            List<ICosmosItem> results = new List<ICosmosItem>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateAsync(string id, ICosmosItem item)
        {
            await _container.UpsertItemAsync<ICosmosItem>(item, new PartitionKey(id));
        }
    }
}
