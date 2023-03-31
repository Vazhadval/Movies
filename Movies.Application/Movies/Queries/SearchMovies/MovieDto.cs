using Movies.Application.Common.Mappings;
using Movies.Application.Common.Models.ApiModels;

namespace Movies.Application.Movies.Queries.SearchMovies
{
    public class MovieDto : IMapFrom<SearchMoviesApiResponse.Movie>
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
