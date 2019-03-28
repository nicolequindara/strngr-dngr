using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class AgeRange
    {
        [JsonProperty(PropertyName = "from")]
        public long From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public long To { get; set; }
    }
}
