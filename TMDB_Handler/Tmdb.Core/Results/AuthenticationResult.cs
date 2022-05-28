namespace Tmdb.Core.Results
{
    public class AuthenticationResult : ResultBase
    {
        public static ResultModel EmailOrPassordInvalid()
        {
            return new ResultModel
            {
                Message = "Email ou senha invalidoss",
                Success = false,
                Data = null
            };
        }

        public static ResultModel Authenticated(string token)
        {
            return new ResultModel
            {
                Message = "Autenticado com sucesso",
                Success = true,
                Data = token
            };
        }
    }
}
