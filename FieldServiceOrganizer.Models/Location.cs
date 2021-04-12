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
            UserId = Guid.NewGuid().ToString();
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
        public string Latitude { get; init; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; init; }
    }
}
