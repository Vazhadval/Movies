using Microsoft.AspNetCore.Mvc;
using Movies.Application.Movies.Commands.AddToWatchList;
using Movies.Application.Movies.Commands.MarkAsWatched;
using Movies.Application.Movies.Queries.GetWatchListItems;
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
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("GetWatchList")]
        public async Task<ActionResult<List<WatchListItemDto>>> GetWatchList([FromQuery] GetWatchListItemsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("AddToWatchList")]
        public async Task<ActionResult<AddToWatchListResult>> AddToWatchList([FromQuery] AddToWatchListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("MarkAsWatched")]
        public async Task<ActionResult<MarkAsWatchedResult>> MarkAsWatched([FromQuery] MarkAsWatchedCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
