namespace Tmdb.Core.Results
{
    public class UserResults : ResultBase
    {
        public static ResultModel UserCreated(object user)
        {
            return new ResultModel
            {
                Message = "Usuario salvo",
                Success = true,
                Data = user
            };
        }

        public static ResultModel UserAlreadyExists()
        {
            return new ResultModel
            {
                Message = "Usuario já cadastrado",
                Success = false,
                Data = null
            };
        }

        public static ResultModel UserNotFound()
        {
            return new ResultModel
            {
                Message = "Usuario não encontrado",
                Success = false,
                Data = null
            };
        }

        public static ResultModel UserFound(object data)
        {
            return new ResultModel
            {
                Message = "Usuario(s) encontrados",
                Success = true,
                Data = data
            };
        }

        public static ResultModel MaxProfile()
        {
            return new ResultModel
            {
                Message = "Usuario não atingiu limite de perfis",
                Success = false,
                Data = null
            };
        }

        public static ResultModel MovieNotFound()
        {
            return new ResultModel
            {
                Message = "Filme não encontrado",
                Success = false,
                Data = null
            };
        }

        public static ResultModel AddedMovie(object data)
        {
            return new ResultModel
            {
                Message = "Filme adicionado",
                Success = true,
                Data = data
            };
        }
    }
}
