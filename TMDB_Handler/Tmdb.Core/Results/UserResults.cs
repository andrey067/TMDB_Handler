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
    }
}
