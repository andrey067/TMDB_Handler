using Bogus;
using Tmdb.API.ViewModels;

namespace Fixtures
{
    public class UserDtoFixtures
    {
        public static CreateUserDto UserDtoValid()
        {
            return new Faker<CreateUserDto>()
                               .RuleFor(u => u.Name, f => f.Name.FullName())
                               .RuleFor(u => u.Email, f => f.Person.Email)
                               .RuleFor(u => u.Password, f => f.Internet.Password())
                               .RuleFor(u => u.Birthday, f => f.Person.DateOfBirth).Generate();
        }
    }
}
