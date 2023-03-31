
using Movies.Application.Common.Models.ApiModels;

namespace Movies.Application.Common.Interfaces
{
    public interface IImdbService
    {
        Task<SearchMoviesApiResponse> SearchMovies(string SearchTerm);
    }
}
