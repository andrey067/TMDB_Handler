namespace Tmdb.Core.Results
{
    public abstract class ResultBase
    {
        public static ResultModel ApplicationErrorMessage(string erro)
        {
            return new ResultModel
            {
                Message = "Ocorreu algum erro interno na aplicação;",
                Success = false,
                Data = erro
            };
        }

        public static ResultModel ErrosForamEncontrados()
        {
            return new ResultModel
            {
                Message = "Alguns campos estão inválidos, por favor corrija-os!",
                Success = false,
                Data = null
            };
        }
    }
}
