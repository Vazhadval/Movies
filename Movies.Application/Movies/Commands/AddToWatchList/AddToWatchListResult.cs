using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Commands.AddToWatchList
{
    public class AddToWatchListResult
    {
        public bool Added { get; set; }
        public string Message { get; set; }
    }
}
