namespace Tmdb.Core.Results
{
    public class ResultModel
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public dynamic Data { get; set; }
    }
}
