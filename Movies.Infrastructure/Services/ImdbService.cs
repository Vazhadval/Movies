using Microsoft.Extensions.Configuration;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.ApiModels;
using Newtonsoft.Json;

namespace Movies.Infrastructure.Services
{
    public class ImdbService : IImdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _urlSearchMovies;
        private readonly string _urlGetMovie;

        public ImdbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ImdbApiSettings:ApiKey"];
            _urlSearchMovies = configuration["ImdbApiSettings:UrlSearchMovies"];
            _urlGetMovie = configuration["ImdbApiSettings:UrlGetSingleMovieByID"];
        }

        public async Task<GetSingleMovieByIdApiResponse> GetSingleMovieById(string id)
        {
            var response = await _httpClient.GetAsync($"{_urlGetMovie}/{_apiKey}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetSingleMovieByIdApiResponse>(responseContent);
            }

            return null;
        }

        public async Task<SearchMoviesApiResponse> SearchMovies(string searchTerm)
        {
            var response = await _httpClient.GetAsync($"{_urlSearchMovies}/{_apiKey}/{searchTerm}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchMoviesApiResponse>(responseContent);
            }

            return null;
        }
    }
}
