using FieldServiceOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FieldServiceOrganizer.Server.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Location>> GetAllAsync(string query);
        Task<Location> GetSingleAsync(string id);
        Task<bool> AddAsync(Location item);
        Task<bool> UpdateAsync(string id, Location item);
        Task DeleteAsync(string id);
    }
}
