using FieldServiceOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public interface IMelissaApiService
    {
        Task<MelissaResponse> GetMelissaNormalizedLocation(Location location);
    }
}
