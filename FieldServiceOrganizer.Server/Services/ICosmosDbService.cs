using FieldServiceOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FieldServiceOrganizer.Server.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<ICosmosItem>> GetAllAsync(string query);
        Task<ICosmosItem> GetSingleAsync(string id);
        Task AddAsync(ICosmosItem item);
        Task UpdateAsync(string id, ICosmosItem item);
        Task DeleteAsync(string id);
    }
}
