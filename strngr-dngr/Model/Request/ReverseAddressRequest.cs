using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Request
{
    [Serializable]
    public class ReverseAddressRequest
    {
        [JsonProperty(PropertyName = "street_line_1")]
        public string StreeLine1 { get; set; }

        [JsonProperty(PropertyName = "street_line_2")]
        public string StreeLine2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "state_code")]
        public string StateCode { get; set; }
    }
}
