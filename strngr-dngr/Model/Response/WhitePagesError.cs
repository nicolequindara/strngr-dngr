using Newtonsoft.Json;

namespace strngr_dngr.Model.Response
{
    public class WhitePagesError
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
