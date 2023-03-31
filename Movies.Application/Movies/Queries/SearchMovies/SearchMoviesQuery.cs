using Application.Movies.Queries.SearchMovies;
using AutoMapper;
using MediatR;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.ApiModels;

namespace Movies.Application.Movies.Queries.SearchMovies
{
    public class SearchMoviesQuery : IRequest<List<MovieDto>>
    {
        public string SearchTerm { get; set; }
    }

    public class SearchMoviesQueryHandler : IRequestHandler<SearchMoviesQuery, List<MovieDto>>
    {
        private readonly IMapper _mapper;
        private readonly IImdbService _imdbService;

        public SearchMoviesQueryHandler(IMapper mapper, IImdbService imdbService)
        {
            _mapper = mapper;
            _imdbService = imdbService;
        }

        public async Task<List<MovieDto>> Handle(SearchMoviesQuery request, CancellationToken cancellationToken)
        {
            var searchMoviesApiResponse = await _imdbService.SearchMovies(request.SearchTerm);
            return _mapper.Map<List<MovieDto>>(searchMoviesApiResponse?.Results ?? new List<SearchMoviesApiResponse.Movie>());
        }
    }
}
