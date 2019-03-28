using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class Resident
    {

        [JsonProperty(PropertyName = "type")]
        public ResidenceType? Type { get; set; }
        
        [JsonProperty(PropertyName = "historical_addresses")]
        public PersonLocationWithEndDate[] HistoricalAddress { get; set; }


        [JsonProperty(PropertyName = "link_to_address_start_date")]
        public string LinkToAddressStartDate { get; set; }


        [JsonProperty(PropertyName = "associated_people")]
        public PersonWithParsedName[] AssociatedPeople { get; set; }


        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }


        [JsonProperty(PropertyName = "age_range")]
        public string AgeRange { get; set; }

        [JsonProperty(PropertyName = "industry")]
        public string[] Industry { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "middlename")]
        public string MiddleName { get; set; }


        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }


        [JsonProperty(PropertyName = "phones")]
        public PhoneWithId[] Phones { get; set; }


        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "alternate_names")]
        public string[] AlternateNames { get; set; }
    }
}
