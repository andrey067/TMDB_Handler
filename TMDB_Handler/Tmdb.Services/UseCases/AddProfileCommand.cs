using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class AddProfileCommand : CommandBase
    {
        public int UserId { get; set; }
        public string NameProfile { get; set; }
    }
}
