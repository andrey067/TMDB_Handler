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
        public List<Profile> Profiles { get; private set; }

        //EF Core
        protected User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        //Autovalida
        public bool Validate() => base.Validate(new UserValidator(), this);
    }
}