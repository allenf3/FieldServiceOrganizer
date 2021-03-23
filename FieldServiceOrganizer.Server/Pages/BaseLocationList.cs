﻿using FieldServiceOrganizer.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Pages
{
    public class BaseLocationList : ComponentBase
    {
        public IEnumerable<Location> Locations { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadLocations();
            return base.OnInitializedAsync();
        }

        private void LoadLocations()
        {
            Location location1 = new Location
            {
                Id = "1",
                OccupantName = "Denny's",
                Direction = "N",
                FullAddress = "123 N. South Street",
                City = "Anytown",
                State = "MO",
                Zip = "55455"
            };
            Location location2 = new Location
            {
                Id = "2",
                OccupantName = "Clementines",
                FullAddress = "555 55Th Ave.",
                City = "Mooresville",
                State = "IL",
                Zip = "84384"
            };
            
            Location location3 = new Location
            {
                Id = "3",
                OccupantName = "Master Auto Repair",
                FullAddress = "928 Beasley St.",
                City = "Greyville",
                State = "NC",
                Zip = "55455-4882"
            };
            
            Location location4 = new Location
            {
                Id = "4",
                OccupantName = "Warby Parker",
                FullAddress = "4886 Highway 17",
                City = "Twosville",
                State = "IL",
                Zip = "88343"
            };
            
            Location location5 = new Location
            {
                Id = "5",
                OccupantName = "Mattress City",
                FullAddress = "9932 Oak Blvd.",
                City = "Yorkshire",
                State = "TN",
                Zip = "85874"
            };

            Locations = new List<Location> { location1, location2, location3, location4, location5 };
        }

    }
}
