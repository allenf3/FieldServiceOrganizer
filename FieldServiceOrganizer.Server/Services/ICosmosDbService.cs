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
        Task<ICosmosItem> GetSingleAsync(string id);
        Task<bool> AddAsync(ICosmosItem item);
        Task<bool> UpdateAsync(string id, ICosmosItem item);
        Task DeleteAsync(string id);
    }
}
