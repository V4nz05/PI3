using Newtonsoft.Json;


namespace Projeto_PI3.Classes
{
    public class ApiService
    {
        private HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<ClimaRoot> GetClimaDataAsync(string cityId)
        {
            var response = await _client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var climaData = JsonConvert.DeserializeObject<ClimaRoot>(content);
            return climaData;
        }

        public async Task<OndaRoot> GetOndaDataAsync(string cityId)
        {
            var response = await _client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/ondas/{cityId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var ondaData = JsonConvert.DeserializeObject<OndaRoot>(content);
            return ondaData;
        }
    }
}
