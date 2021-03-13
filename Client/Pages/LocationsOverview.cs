using System;
using System.Collections.Generic;
using FieldServiceOrganizer.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Client.Pages
{
    public partial class LocationsOverview
    {
        //Dummy data

        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

    }
}
