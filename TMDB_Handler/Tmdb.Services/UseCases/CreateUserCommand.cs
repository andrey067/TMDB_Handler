using Tmdb.Core.Utils;

namespace Tmdb.Infra.UseCases
{
    public class CreateUserCommand : CommandBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
    }
}
