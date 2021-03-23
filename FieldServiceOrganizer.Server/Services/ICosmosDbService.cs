using FieldServiceOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Location>> GetLocationsAsync(string query);
        Task<Location> GetLocationAsync(string id);
        Task AddLocationAsync(Location location);
        Task UpdateLocationAsync(string id, Location location);
        Task DeleteLocationAsync(string id);
    }
}
