using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class Subscriber
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "age_range")]
        public AgeRange AgeRange { get; set; }
    }
}
