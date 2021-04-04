using Azure.Cosmos;
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

            newLocation.OccupantName = string.Empty;
            newLocation.FullAddress = string.Empty;
            newLocation.City = string.Empty;
            newLocation.State = string.Empty;
            newLocation.Zip = string.Empty;

            return Locations;
        }

        private async Task DeleteLocation(Location location)
        {
            await _cosmosDbService.DeleteAsync(location);
        }
        
    }
}
