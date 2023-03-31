using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Movies.Application.Common.Models.ApiModels
{
    public class GetSingleMovieByIdApiResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("plot")]
        public string Plot { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
