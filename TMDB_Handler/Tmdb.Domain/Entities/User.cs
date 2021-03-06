using Tmdb.Domain.Validators;
using Tmdb.Domain.ValueObject;

namespace Tmdb.Domain.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthday { get; private set; }
        private List<Profile> _profiles;
        public IReadOnlyCollection<Profile> Profiles => _profiles;

        //EF Core
        protected User()
        {
            _profiles = new();
            _errors = new List<string>();
        }

        public User(string name, string email, string password, DateTime birthday)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Password = password;
            _errors = new List<string>();
            _profiles = new();
            Validate();
        }

        //Autovalida
        public bool Validate() => base.Validate(new UserValidator(), this);

        public void AddProfile(Profile profile)
        {
            _profiles.Add(profile);
        }
    }
}