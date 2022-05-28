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
        protected User() { }

        public User(string name, string email, DateTime birthday)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            _profiles = new();
            _errors = new List<string>();
            Validate();
        }
        public User(string name, string email, string password, DateTime birthday)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Password = password;
            _profiles = new();
            _errors = new List<string>();
            Validate();
        }

        //Autovalida
        public bool Validate() => base.Validate(new UserValidator(), this);
        public bool AutenticationValidate() => base.Validate(new AutententicationValidator(), this);
    }
}