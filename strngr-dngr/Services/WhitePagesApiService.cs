using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using strngr_dngr.Model.Request;
using strngr_dngr.Model.Response.WhitePages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace strngr_dngr.Services
{
    public interface IWhitePagesApiService
    {
        Task<ReverseAddressResponse> ReverseAddress(ReverseAddressRequest request);
        Task<IdentityCheckResponse> IdentityCheck(IdentityCheckRequest request);
    }

    public class WhitePagesApiService : IWhitePagesApiService
    {
        private readonly HttpClient _client;

        private const string ReverseAddressUrl = "https://proapi.whitepages.com/3.0/location";
        private const string IdentityCheckUrl = "https://proapi.whitepages.com/3.3/identity_check";
        private const string ReverseAddressApiKey = "6e977451a22a422f9087b5c4f37cf42b";
        private const string IdentityCheckApiKey = "1f32c3cc0b27411fa723e45a79ab83f5";

        public WhitePagesApiService()
        {
            _client = new HttpClient();
        }

        public async Task<ReverseAddressResponse> ReverseAddress(ReverseAddressRequest request)
        {
            var requestUrl = FormatReverseAddressQueryUrl(request);
            var response = await _client.PostAsync(requestUrl, null);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReverseAddressResponse>(content);
        }

        public async Task<IdentityCheckResponse> IdentityCheck(IdentityCheckRequest request)
        {
            var requestUrl = FormatIdentityCheckQueryUrl(request);
            var response = await _client.PostAsync(requestUrl, null);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IdentityCheckResponse>(content);
        }

        private string FormatReverseAddressQueryUrl(ReverseAddressRequest request)
        {
            var queryParameters = new List<string>();
            queryParameters.Add($"api_key={ReverseAddressApiKey}");
            queryParameters.Add($"street_line_1={ HttpUtility.UrlEncode(request.StreeLine1)}");
            if(!string.IsNullOrEmpty(request.StreeLine2)) queryParameters.Add($"street_line_2={ HttpUtility.UrlEncode(request.StreeLine2)}");
            queryParameters.Add($"city={ HttpUtility.UrlEncode(request.City)}");
            queryParameters.Add($"state_code={request.StateCode}");
            queryParameters.Add($"postal_code={request.PostalCode}");
            queryParameters.Add($"country_code=US");

            return CreateUrl(ReverseAddressUrl, queryParameters);
        }

        private string FormatIdentityCheckQueryUrl(IdentityCheckRequest request)
        {
            var queryParameters = new List<string>();
            queryParameters.Add($"api_key={IdentityCheckApiKey}");
            queryParameters.Add("primary.address.country_code=US");
            if (!string.IsNullOrEmpty(request.City)) queryParameters.Add($" primary.address.city={ HttpUtility.UrlEncode(request.City)}");
            if (!string.IsNullOrEmpty(request.Name)) queryParameters.Add($" primary.name={ HttpUtility.UrlEncode(request.Name)}");
            if (!string.IsNullOrEmpty(request.Phone)) queryParameters.Add($" primary.phone={ HttpUtility.UrlEncode(request.Phone)}");
            if (!string.IsNullOrEmpty(request.StreetLine1)) queryParameters.Add($" primary.address.street_line_1={ HttpUtility.UrlEncode(request.StreetLine1)}");
            if (!string.IsNullOrEmpty(request.StreetLine2)) queryParameters.Add($" primary.address.street_line_2={ HttpUtility.UrlEncode(request.StreetLine2)}");
            if (!string.IsNullOrEmpty(request.EmailAddress)) queryParameters.Add($" primary.email_address={ HttpUtility.UrlEncode(request.EmailAddress)}");
            if (!string.IsNullOrEmpty(request.PostalCode)) queryParameters.Add($" primary.address.postal_code={ HttpUtility.UrlEncode(request.PostalCode)}");
            if (!string.IsNullOrEmpty(request.StateCode)) queryParameters.Add($" primary.address.state_Code={ HttpUtility.UrlEncode(request.StateCode)}");
            if (!string.IsNullOrEmpty(request.Phone)) queryParameters.Add($" primary.phone={ HttpUtility.UrlEncode(request.Phone)}");

            return CreateUrl(IdentityCheckUrl, queryParameters);
        }

        private string CreateUrl(string baseUrl, List<string> queryParams) => $"{baseUrl}?{queryParams.Join("&")}";
    }
}
