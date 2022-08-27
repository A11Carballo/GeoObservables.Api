using System.Net.Http.Headers;
using GeoObservables.Api.Aplication.Contracts.ApiCaller;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using Newtonsoft.Json;

namespace GeoObservables.Api.Aplication.ApiCaller
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _httpClient;
        private readonly IAppConfig _appConfig;

        public ApiCaller(IAppConfig appConfig)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(appConfig.ServiceUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<T> GetServiceResponseById<T>(string controller, int id)
        {

            var response = await _httpClient.GetAsync(string.Format("/{0}/{1}", controller, id));

            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);

        }

    }
}
