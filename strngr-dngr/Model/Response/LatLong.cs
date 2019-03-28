using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Response
{
    [Serializable]
    public class LatLong
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "accuracy")]
        public string Accuracy { get; set; }
    }
}
