using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Request
{

    [Serializable]
    public class IncandescentGetRequest : BaseIncandescentRequest
    {
        public IncandescentGetRequest(string projectId)
        {
            ProjectId = projectId;
        }

        [JsonProperty(PropertyName = "project_id")]
        public string ProjectId { get; private set; }
    }
}
