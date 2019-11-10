using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Model;

namespace WoooliesX.Service
{
    public class TrolleyService : ITrolleyService
    {
        private readonly HttpClient _httpClient;

        public TrolleyService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<decimal> TrolleyTotal(TrolleyRequest request)
        {
            return await ResourceLookup<decimal>(Constants.Url.TrolleyCalculatorApiUrl, request);
        }

        private async Task<decimal> ResourceLookup<T>(string resourceEndpoint, TrolleyRequest request)
        {
            var requestObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var response = await _httpClient.PostAsync($"{resourceEndpoint}?token={Constants.Authentication.Token}", new StringContent(requestObject, Encoding.UTF8, "application/json"));
            var readResponse = await response.Content.ReadAsStringAsync();

            if (decimal.TryParse(readResponse, out decimal temp))
            {
                return temp;
            }

            return 0M;
        }

    }
}
