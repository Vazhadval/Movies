using System.Text.Json.Serialization;

namespace Movies.Application.Common.Models.ApiModels
{
    public class SearchMoviesApiResponse
    {
        [JsonPropertyName("searchType")]
        public string SearchType { get; set; }
        [JsonPropertyName("expression")]
        public string Expression { get; set; }
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }

        public class Movie
        {
            [JsonPropertyName("Id")]
            public string Id { get; set; }
            [JsonPropertyName("resultType")]
            public string ResultType { get; set; }
            [JsonPropertyName("image")]
            public string Image { get; set; }
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
        }
    }
}
