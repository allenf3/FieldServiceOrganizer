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

        public async Task AddLocationAsync(Location location)
        {
            await _container.CreateItemAsync<Location>(location, new PartitionKey(location.Id));
        }

        public async Task DeleteLocationAsync(string id)
        {
            await _container.DeleteItemAsync<Location>(id, new PartitionKey(id));
        }

        public async Task<Location> GetLocationAsync(string id)
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

        public async Task<IEnumerable<Location>> GetLocationsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Location>(new QueryDefinition(queryString));
            List<Location> results = new List<Location>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateLocationAsync(string id, Location location)
        {
            await _container.UpsertItemAsync<Location>(location, new PartitionKey(id));
        }
    }
}
