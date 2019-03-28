using Newtonsoft.Json;
using System;

namespace strngr_dngr.Model.Response.WhitePages
{
    [Serializable]
    public class IdentityCheckResponse
    {
        [JsonProperty(PropertyName = "primary_phone_checks")]
        public PhoneChecks PrimaryPhoneChecks { get; set; }

        [JsonProperty(PropertyName = "primary_address_checks")]
        public AddressChecks PrimaryAddressChecks { get; set; }

        [JsonProperty(PropertyName = "primary_email_address_checks")]
        public EmailChecks PrimaryEmailAddressChecks { get; set; }

        [JsonProperty(PropertyName = "identity_check_score")]
        public long IdentityCheckScore { get; set; }
    }
}
