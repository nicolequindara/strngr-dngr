using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class PhoneWithId
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "line_type")]
        public LineType? Type { get; set; }
    }
}
