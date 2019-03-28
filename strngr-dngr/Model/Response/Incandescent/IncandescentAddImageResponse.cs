using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.Incandescent
{

    [Serializable]
    public class IncandescentAddImageResponse
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public string ProjectId { get; set; }
    }
}
