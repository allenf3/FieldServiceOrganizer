﻿using Azure.Cosmos;
using FieldServiceOrganizer.Models;
using FieldServiceOrganizer.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Pages
{
    public partial class LocationList : ComponentBase
    {
        public List<Location> Locations { get; set; }
        private readonly Location newLocation = new();
        private EditContext editContext;
        private ICosmosDbService _cosmosDbService;

        protected override async Task OnInitializedAsync()
        {
            _cosmosDbService = CosmosDbService;
            await LoadLocations();
            // return base.OnInitializedAsync();
        }

        private async void AddLocation()
        {
            editContext = new EditContext(newLocation);
            bool isValid = editContext.Validate();
            if (isValid)
            {
                newLocation.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddAsync(newLocation);
            }
            await LoadLocations();
        }

        private async Task<IEnumerable<Location>> LoadLocations()
        {
            Locations = new List<Location>();
            var locations = await _cosmosDbService.GetAllAsync($"select * from c");
            foreach (var item in locations)
            {
                Locations.Add(item);
            }
            return Locations;



            //await foreach (var item in cosmosItems)
            //{
            //    locations.Add(item);
            //}
            //return locations;
        }
            //Location location1 = new Location
            //{
            //    Id = "1",
            //    OccupantName = "Denny's",
            //    Direction = "N",
            //    FullAddress = "123 N. South Street",
            //    City = "Anytown",
            //    State = "MO",
            //    Zip = "55455"
            //};
            //Location location2 = new Location
            //{
            //    Id = "2",
            //    OccupantName = "Clementines",
            //    FullAddress = "555 55Th Ave.",
            //    City = "Mooresville",
            //    State = "IL",
            //    Zip = "84384"
            //};
            
            //Location location3 = new Location
            //{
            //    Id = "3",
            //    OccupantName = "Master Auto Repair",
            //    FullAddress = "928 Beasley St.",
            //    City = "Greyville",
            //    State = "NC",
            //    Zip = "55455-4882"
            //};
            
            //Location location4 = new Location
            //{
            //    Id = "4",
            //    OccupantName = "Warby Parker",
            //    FullAddress = "4886 Highway 17",
            //    City = "Twosville",
            //    State = "IL",
            //    Zip = "88343"
            //};
            
            //Location location5 = new Location
            //{
            //    Id = "5",
            //    OccupantName = "Mattress City",
            //    FullAddress = "9932 Oak Blvd.",
            //    City = "Yorkshire",
            //    State = "TN",
            //    Zip = "85874"
            //};

            //Locations = new List<Location> { location1, location2, location3, location4, location5 };

            //newLocation.OccupantName = string.Empty;
            //newLocation.FullAddress = string.Empty;
            //newLocation.City = string.Empty;
            //newLocation.State = string.Empty;
            //newLocation.Zip = string.Empty;
        
    }
}