using Azure.Cosmos;
using FieldServiceOrganizer.Models;
using FieldServiceOrganizer.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Pages
{
    public partial class LocationList : ComponentBase
    {
        public List<Location> Locations { get; set; }
        public ObservableCollection<Location> SelectedLocations { get; set; }

        SfGrid<Location> Grid;
        private List<double> SelectedRowIndexes { get; set; }
        private double[] TotalValue { get; set; }
        private int TotalSelected = 0;
        private string SelectedValue;
        private EditContext editContext;
        private ICosmosDbService _cosmosDbService;
        private IMelissaApiService _melissaApiService;

        protected override async Task OnInitializedAsync()
        {
            _cosmosDbService = CosmosDbService;
            _melissaApiService = MelissaApiService;
            await LoadLocations();
        }

        private async Task<IEnumerable<Location>> LoadLocations()
        {
            Locations = new List<Location>();
            SelectedLocations = new ObservableCollection<Location>();
            var locations = await _cosmosDbService.GetAllAsync($"select * from c");
            foreach (var item in locations)
            {
                Locations.Add(item);
            }
            return Locations;
        }

        private async Task OnCommandClicked(CommandClickEventArgs<Location> args)
        {
            if (args.CommandColumn.Type == CommandButtonType.Delete)
            {
                await _cosmosDbService.DeleteAsync(args.RowData);
            }
        }

        private async Task OnActionBeginHandler(ActionEventArgs<Location> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save && args.Action == "Add")
            {
                editContext = new EditContext(args.Data);
                bool isValid = editContext.Validate();
                if (isValid)
                {
                    var response = await _melissaApiService.GetMelissaNormalizedLocation(args.Data);
                    var melissaNormalizedAddress = response.Records[0];
                    args.RowData.NormalizeLocation(melissaNormalizedAddress);
                    await _cosmosDbService.AddAsync(args.Data);
                }
            }
        }

        private async Task GetSelectedRecords(RowSelectEventArgs<Location> args)
        {
            TotalSelected++;
            SelectedLocations.Add(args.Data);
            SelectedRowIndexes = await Grid.GetSelectedRowIndexes();
            TotalValue = SelectedRowIndexes.ToArray();
            SelectedValue = "";
            foreach (var data in TotalValue)
            {
                SelectedValue = SelectedValue + " " + data;
            }
            StateHasChanged();
        }

        private void RowDeselectHandler(RowDeselectEventArgs<Location> args)
        {
            TotalSelected--;
            SelectedLocations.Remove(args.Data);
            StateHasChanged();
        }
    }
}
