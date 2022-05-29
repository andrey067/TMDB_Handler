using Tmdb.Domain.Entities;
using Tmdb.Domain.Enums;

namespace Tmdb.Domain.ValueObject
{
    public class Profile
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public int TypeProfile { get; private set; }
        public List<Movie> Movies { get; private set; }

        private Profile(string name, int typeProfile)
        {
            Name = name;
            TypeProfile = (int)(ETypeProfile)typeProfile;
            Movies = new();
        }

        public static Profile CreateHostProfile(string name)
        {
            return new Profile(name, (int)ETypeProfile.Host);
        }

        public static Profile CreateGuestProfile(string name)
        {
            return new Profile(name, (int)ETypeProfile.Guest);
        }
    }
}