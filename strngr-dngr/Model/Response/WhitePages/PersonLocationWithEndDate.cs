using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class PersonLocationWithEndDate : WhitePagesAddress
    {
        [JsonProperty(PropertyName = "location_type")]
        public LocationType LocationType { get; set; }

        [JsonProperty(PropertyName = "delivery_point")]
        public string DeliveryPoint { get; set; }

        [JsonProperty(PropertyName = "link_to_person_start_date")]
        public string LinkToPersonStartDate { get; set; }

        [JsonProperty(PropertyName = "link_to_person_end_date")]
        public string LinkToPersonEndDate { get; set; }
    }
}
