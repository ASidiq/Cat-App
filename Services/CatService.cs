using CatApp.Interfaces;
using CatApp.Models;
using Newtonsoft.Json;

namespace CatApp.Services
{
    public class CatService : ICatService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public CatService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<List<Cat>> GetCatUrls()
        {
            List<Cat> catUrls = new();

            string url = $"{_configuration["ApiUrl"]}/images/search?limit={_configuration["LimitValue"]}";

            _client.DefaultRequestHeaders.Add("x-api-key", _configuration["ApiKey"]);
            try
            {
                var response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                catUrls = JsonConvert.DeserializeObject<List<Cat>>(responseString);

                return catUrls;


            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while trying to retrieve cat image url frm cat api", ex);

            }
        }
    }
}
