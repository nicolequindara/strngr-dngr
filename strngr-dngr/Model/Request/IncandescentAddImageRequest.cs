using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Request
{
    [Serializable]
    public class IncandescentAddImageRequest : BaseIncandescentRequest
    {
        public IncandescentAddImageRequest(IEnumerable<string> imageUrls) : base()
        {
            Images = imageUrls.ToArray();
        }


        [JsonProperty(PropertyName = "images")]
        public string[] Images { get; set; }
    }
}
