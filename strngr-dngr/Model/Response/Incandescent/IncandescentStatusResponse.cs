using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response
{
    [Serializable]
    public class IncandescentStatusResponse
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
    }
}
