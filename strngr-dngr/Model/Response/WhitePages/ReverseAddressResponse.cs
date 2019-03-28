using System;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class ReverseAddressResponse : WhitePagesAddress
    {
        [JsonProperty(PropertyName = "is_commercial")]
        public bool IsCommercial { get; set; }

        [JsonProperty(PropertyName = "is_forwarder")]
        public bool IsForwarder { get; set; }
        
        [JsonProperty(PropertyName = "current_residents")]
        public Resident[] CurrentResidents { get; set; }
        
        [JsonProperty(PropertyName = "last_sale_date")]
        public string LastSaleDate { get; set; }

        [JsonProperty(PropertyName = "total_value")]
        public long TotalValue { get; set; }
        
        [JsonProperty(PropertyName = "owners")]
        public Owner[] Owners { get; set; }
        
        [JsonProperty(PropertyName = "associated_addresses")]
        public AddressWithPropertyData[] AssociatedAddresses { get; set; }

        [JsonProperty(PropertyName = "error")]
        public WhitePagesError Error { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }
    }
}
