using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class SearchMovieRequest : CommandBase
    {
        public SearchMovieRequest(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
