using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace Fixtures
{
    public class BaseClient : IDisposable
    {
        public HttpClient _client { get; private set; }
        public string hostApi { get; set; }
        private readonly WebApplicationFactory<Program> _factory;

        public BaseClient()
        {
            hostApi = "https://localhost:7281";
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        public async Task<HttpResponseMessage> GetJsonAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url)
        {
            return await _client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
        }

        public void Dispose() => _client.Dispose();

    }
}
