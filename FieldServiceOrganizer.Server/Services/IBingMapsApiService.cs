using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FieldServiceOrganizer.Models;

namespace FieldServiceOrganizer.Server.Services
{
    public interface IBingMapsApiService
    {
        Task<BingMapsResponse> GetPointToPointRoute(Location From, Location To);
    }
}
