using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace strngr_dngr.Model.Response.OffenderLookup
{
    /// <summary>
    /// https://www.backgroundcheckapi.com/outputexamples.html
    /// </summary>
    [Serializable]
	public class OffenderLookupResponse
	{
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "middlename")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "county")]
        public string County { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "birth_year")]
        public int BirthYear { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CrimeType Type { get; set; }

        [JsonProperty(PropertyName = "crime_description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "is_exact_match")]
        public bool? ExactMatch { get; set; }
    }
}
