using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class WhitePagesAddress
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty(PropertyName = "street_line_1")]
        public string StreetLine1 { get; set; }

        [JsonProperty(PropertyName = "street_line_2")]
        public string StreetLine2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "zip4")]
        public string Zip4 { get; set; }

        [JsonProperty(PropertyName = "state_code")]
        public string StateCode { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "lat_long")]
        public LatLong LatLong { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }
    }
}
