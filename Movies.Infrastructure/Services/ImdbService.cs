using Microsoft.Extensions.Configuration;
using Movies.Application.Common.Interfaces;
using Newtonsoft.Json;
using Movies.Application.Common.Models.ApiModels;

namespace Movies.Infrastructure.Services
{
    public class ImdbService : IImdbService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ImdbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<SearchMoviesApiResponse> SearchMovies(string SearchTerm)
        {
            var apiKey = _configuration["ImdbApiSettings:ApiKey"];
            var urlMoviesSearch = _configuration["ImdbApiSettings:UrlSearchMovies"];
            var response = await _httpClient.GetAsync($"{urlMoviesSearch}/{apiKey}/{SearchTerm}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchMoviesApiResponse>(responseContent);
            }

            return null;
        }
    }
}
