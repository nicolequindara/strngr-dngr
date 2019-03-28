using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using strngr_dngr.Model.Request;
using strngr_dngr.Model.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace strngr_dngr.Services
{
    public interface IWhitePagesApiService
    {
        Task<ReverseAddressResponse> ReverseAddress(ReverseAddressRequest request);
    }

    public class WhitePagesApiService : IWhitePagesApiService
    {
        private readonly HttpClient _client;

        private const string ReverseAddressUrl = "https://proapi.whitepages.com/3.0/location";
        private const string ReverseAddressApiKey = "6e977451a22a422f9087b5c4f37cf42b";

        public WhitePagesApiService()
        {
            _client = new HttpClient();
        }

        public async Task<ReverseAddressResponse> ReverseAddress(ReverseAddressRequest request)
        {
            var requestUrl = FormatQueryUrl(request);
            var response = await _client.PostAsync(requestUrl, null);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReverseAddressResponse>(content);
        }

        private string FormatQueryUrl(ReverseAddressRequest request)
        {
            var queryParameters = new List<string>();
            queryParameters.Add($"api_key={ReverseAddressApiKey}");
            queryParameters.Add($"street_line_1={ HttpUtility.UrlEncode(request.StreeLine1)}");
            if(!string.IsNullOrEmpty(request.StreeLine2)) queryParameters.Add($"street_line_2={ HttpUtility.UrlEncode(request.StreeLine2)}");
            queryParameters.Add($"city={ HttpUtility.UrlEncode(request.City)}");
            queryParameters.Add($"state_code={request.StateCode}");
            queryParameters.Add($"postal_code={request.PostalCode}");
            queryParameters.Add($"country_code=US");

            return$"{ReverseAddressUrl}?{queryParameters.Join("&")}";


        }
    }
}
