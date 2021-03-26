using System;
using System.Collections.Generic;
using FieldServiceOrganizer.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Client.Pages
{
    public partial class LocationsOverview
    {
        public IEnumerable<Location> Locations { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeLocations();

            return base.OnInitializedAsync();
        }

        private void InitializeLocations()
        {
            Locations = new List<Location>()
            {
                new Location
                {
                    Id = 1,
                    OccupantName = "Clementines",
                    Address = new MelissaAddress
                    {
                        FormattedAddress = "1637 S 18th St; Saint Louis, MO 63104 - 2503",
                        AddressLine1 = "1637 S 18th St",
                        AddressLine2 = "Saint Louis, MO 63104 - 2503",
                        Locality = "Saint Louis",
                        SubAdministrativeArea = "Saint Louis City",
                        AdministrativeArea = "MO",
                        PostalCode = "63104 - 2503",
                        AddressType = "S",
                        AddressKey = "63104250337",
                        CountryName = "United States of America",
                        CountryISO3166_1_Alpha2 = "US",
                        CountryISO3166_1_Alpha3 = "USA",
                        CountryISO3166_1_Numeric = "840",
                        CountrySubdivisionCode = "US-MO",
                        Thoroughfare = "S 18th St",
                        ThoroughfarePreDirection = "S",
                        ThoroughfareName = "18th",
                        ThoroughfareTrailingType = "St",
                        PremisesNumber = "1637",
                        Latitude = "38.614457",
                        Longitude = "-90.211965",
                        DeliveryIndicator = "U",
                        MelissaAddressKey = "1316944658",
                        UTC = "UTC-06:00",
                        DST = "Y",
                        CensusKey = "295101232002003"
                    }
                },
                new Location
                {
                    Id = 2,
                    OccupantName = "Master Auto Repair",
                    Address = new MelissaAddress
                    {
                        FormattedAddress = "206 Vandalia St; Collinsville, IL 62234 - 3548",
                        AddressLine1 = "206 Vandalia St",
                        AddressLine2 = "Collinsville, IL 62234 - 3548",
                        Locality = "Collinsville",
                        SubAdministrativeArea = "Madison",
                        AdministrativeArea = "IL",
                        PostalCode = "62234 - 3548",
                        AddressType = "S",
                        AddressKey = "62234354806",
                        CountryName = "United States of America",
                        CountryISO3166_1_Alpha2 = "US",
                        CountryISO3166_1_Alpha3 = "USA",
                        CountryISO3166_1_Numeric = "840",
                        CountrySubdivisionCode = "US - IL",
                        Thoroughfare = "Vandalia St",
                        ThoroughfareName = "Vandalia",
                        ThoroughfareTrailingType = "St",
                        PremisesNumber = "206",
                        Latitude = "38.672143",
                        Longitude = "- 89.984322",
                        DeliveryIndicator = "B",
                        MelissaAddressKey = "9879804777",
                        UTC = "UTC - 06:00",
                        DST = "Y",
                        CensusKey = "171194033001025"
                    }
                }
                //new Location
                //{
                //    Id = 3

                //},
                //new Location
                //{
                //    Id = 4

                //},
                //new Location
                //{
                //    Id = 5

                //},
                //new Location
                //{
                //    Id = 6

                //},
                //new Location
                //{
                //    Id = 7

                //},
                //new Location
                //{
                //    Id = 8

                //},
                //new Location
                //{
                //    Id = 9

                //},
                //new Location
                //{
                //    Id = 10

                //},
                //new Location
                //{
                //    Id = 11

                //},
                //new Location
                //{
                //    Id =12

                //}
            };
        }

    }
}
