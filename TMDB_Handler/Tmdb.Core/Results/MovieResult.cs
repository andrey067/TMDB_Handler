namespace Tmdb.Core.Results
{
    public class MovieResult : ResultBase
    {
        public static ResultModel ReturnMovies(object data)
        {
            return new ResultModel
            {
                Message = "Lista de filmes encontrados",
                Success = true,
                Data = data
            };
        }

        public static ResultModel NoMoviesFound()
        {
            return new ResultModel
            {
                Message = "filme(s) não encontrados",
                Success = false,
                Data = null
            };
        }

        public static ResultModel AddWatchList(object data)
        {
            return new ResultModel
            {
                Message = "Filme adicionado à sua lista de filmes",
                Success = true,
                Data = data
            };
        }

        public static ResultModel AddWatched(object data)
        {
            return new ResultModel
            {
                Message = "Filme adicionado adcionado como assistido",
                Success = true,
                Data = data
            };
        }
    }
}
