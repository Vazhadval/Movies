using Microsoft.AspNetCore.Mvc;
using Movies.Application.Movies.Queries.SearchMovies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    public class WatchlListsController : ApiControllerBase
    {
        [HttpGet("SearchMovies")]
        public async Task<ActionResult<List<MovieDto>>> SearchMovies([FromQuery] SearchMoviesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
