using FieldServiceOrganizer.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Pages
{
    public class BaseLocationList : ComponentBase
    {
        private void LoadLocations()
        {
            Location location1 = new Location
            {
                Id = "1",
                OccupantName = "Denny's",
                FullAddress = "123 South Street",

            };
        }

    }
}
