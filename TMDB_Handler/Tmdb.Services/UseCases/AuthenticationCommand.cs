using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class AuthenticationCommand : CommandBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
