using Blazor.ApiClient.Models;
using System.Net.Http;

namespace Blazor.ApiClient
{
    public class BlazorApiClientServices
    {
        private readonly HttpClient _httpClient;

        public BlazorApiClientServices(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAdress); 

        }
    }
}
