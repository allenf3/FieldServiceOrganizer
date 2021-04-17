using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FieldServiceOrganizer.Models
{
    public class Location
    {
        public Location()
        {
            Type = GetType().Name;
            Id = Guid.NewGuid();
            UserId = new Guid("a8363ca0171247e28540a75abd811c3f").ToString();
        }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; init; }


        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; init; }

        [JsonProperty(PropertyName = "occupantName")]
        public string OccupantName { get; set; }

        [JsonProperty(PropertyName = "streetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        [JsonProperty(PropertyName = "fullAddress")]
        public string FullAddress { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; init; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   FullAddress == location.FullAddress &&
                   City == location.City &&
                   State == location.State &&
                   Zip == location.Zip;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullAddress, City, State, Zip);
        }

        public void NormalizeLocation(MelissaNormalizedLocation normalizedLocation)
        {
            StreetNumber = normalizedLocation.PremisesNumber;
            Direction = normalizedLocation.ThoroughfarePreDirection;
            Street = normalizedLocation.ThoroughfareName;
            Unit = normalizedLocation.SubPremisesNumber;
            FullAddress = normalizedLocation.AddressLine1;
            City = normalizedLocation.Locality;
            State = normalizedLocation.AdministrativeArea;
            Zip = normalizedLocation.PostalCode;
            Latitude = normalizedLocation.Latitude;
            Longitude = normalizedLocation.Longitude;
        }


    }
}
