using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Request
{
    [Serializable]
    public class IdentityCheckRequest
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "street_line_1")]
        public string StreetLine1 { get; set; }

        [JsonProperty(PropertyName = "street_line_2")]
        public string StreetLine2 { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "state_code")]
        public string StateCode { get; set; }

    }
}
