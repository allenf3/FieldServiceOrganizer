using FieldServiceOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public class MelissaApiService : IMelissaApiService
    {
        public Task<MelissaNormalizedLocation> GetNormalizedLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
