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
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

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
        public bool FullAddress { get; set; }

        [JsonProperty(PropertyName = "city")]
        public bool City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public bool State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }
    }
}
