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
    }
}
