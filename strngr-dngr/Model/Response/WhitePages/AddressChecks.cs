using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class AddressChecks
    {

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }

        [JsonProperty(PropertyName = "is_valid")]
        public bool? IsValid { get; set; }

        [JsonProperty(PropertyName = "input_completeness")]
        public string InputCompleteness { get; set; }

        [JsonProperty(PropertyName = "match_to_name")]
        public string MatchToName { get; set; }

        [JsonProperty(PropertyName = "resident")]
        public Subscriber Resident { get; set; }

        [JsonProperty(PropertyName = "is_commercial")]
        public bool? IsCommercial { get; set; }

        [JsonProperty(PropertyName = "is_forwarder")]
        public bool? IsForwarder { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
