namespace Tmdb.CrossCutting.Http
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        private readonly string _apiKey = "";

        public ApiKeyMessageHandler(string apiKey)
        {
            _apiKey = apiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri($"{request.RequestUri}?api_key={_apiKey}");
            request.Headers.Add("api_key", _apiKey);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
