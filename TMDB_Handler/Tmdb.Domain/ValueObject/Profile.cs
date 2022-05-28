using Tmdb.Domain.Entities;

namespace Tmdb.Domain.ValueObject
{
    public class Profile
    {
        public int UserId { get; private set; }
        public string Nome { get; private set; }
        //public List<Movie> Movies { get; private set; }
    }
}