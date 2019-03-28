using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class PhoneChecks
    {
        [JsonProperty(PropertyName = "error")]
        public WhitePagesError Error { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }

        [JsonProperty(PropertyName = "is_valid")]
        public bool? IsValid { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "is_commercial")]
        public bool? IsCommercial { get; set; }

        [JsonProperty(PropertyName = "line_type")]
        public LineType? LineType { get; set; }

        [JsonProperty(PropertyName = "carrier")]
        public string Carrier { get; set; }

        [JsonProperty(PropertyName = "is_prepaid")]
        public bool? IsPrepaid { get; set; }

        [JsonProperty(PropertyName = "match_to_name")]
        public string MatchToName { get; set; }

        [JsonProperty(PropertyName = "match_to_address")]
        public string MatchToAddress { get; set; }

        [JsonProperty(PropertyName = "subscriber")]
        public Subscriber Subscriber { get; set; }
    }
}
