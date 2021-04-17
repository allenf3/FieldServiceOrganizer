using Azure.Cosmos;
using FieldServiceOrganizer.Models;
using FieldServiceOrganizer.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Grids;
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
        private IMelissaApiService _melissaApiService;

        protected override async Task OnInitializedAsync()
        {
            _cosmosDbService = CosmosDbService;
            _melissaApiService = MelissaApiService;
            await LoadLocations();
        }

        private async Task AddLocation()
        {
            editContext = new EditContext(newLocation);
            bool isValid = editContext.Validate();
            if (isValid)
            {
                var response = await _melissaApiService.GetMelissaNormalizedLocation(newLocation);
                var melissaNormalizedAddress = response.Records[0];
                newLocation.NormalizeLocation(melissaNormalizedAddress);
                await _cosmosDbService.AddAsync(newLocation);
                Locations = (await LoadLocations()).ToList();

                ClearFormFields();
            }
        }

        private void ClearFormFields()
        {
            newLocation.OccupantName = string.Empty;
            newLocation.FullAddress = string.Empty;
            newLocation.City = string.Empty;
            newLocation.State = string.Empty;
            newLocation.Zip = string.Empty;
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
        }

        private async Task DeleteLocation(Location location)
        {
            await _cosmosDbService.DeleteAsync(location);
            Locations = (await LoadLocations()).ToList();
        }

        private async Task OnCommandClicked(CommandClickEventArgs<Location> args)
        {
            if (args.CommandColumn.Type == CommandButtonType.Delete)
            {
                await _cosmosDbService.DeleteAsync(args.RowData);
                Locations = (await LoadLocations()).ToList();
            }
        }
        
    }
}
