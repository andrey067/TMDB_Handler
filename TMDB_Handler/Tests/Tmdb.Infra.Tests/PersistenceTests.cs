using Bogus;
using Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Tmdb.Domain.Entities;
using Tmdb.Domain.Enums;
using Tmdb.Domain.ValueObject;
using Tmdb.Infra.Context;
using Tmdb.Infra.Repository;

namespace Tmdb.Infra.Tests
{
    public class PersistenceTests : IClassFixture<DbTests>, IDisposable
    {
        private ServiceProvider _serviceProvider;
        private TmdbContext _tmdbContext;

        public PersistenceTests(DbTests context) => _serviceProvider = context.ServiceProvider;

        [Trait("Persistencia de Dados", "User")]
        [Fact(DisplayName = "É possivel Persistir a usuario")]
        public async Task PersistingUser()
        {
            //Arrange
            await StartingDatabase();
            var userdto = UserDtoFixtures.UserDtoValid();
            var userRepository = new UserRepository(_tmdbContext);
            var userFaker = new User(userdto.Name, userdto.Email, userdto.Password, userdto.Birthday);

            //Action
            User savedUser = await userRepository.Create(userFaker);

            //Assert
            Assert.NotEqual(0, savedUser.Id);
            Assert.Equal(userFaker.Name, savedUser.Name);
            Assert.Equal(userFaker.Email, savedUser.Email);
            Assert.NotNull(savedUser.Profiles.FirstOrDefault());
        }

        [Trait("Persistencia de Dados", "User")]
        [Fact(DisplayName = "É possivel crirar perfil a usuario")]
        public async Task CreateGuestUser()
        {
            //Arrange
            await StartingDatabase();
            var userdto = UserDtoFixtures.UserDtoValid();
            var userRepository = new UserRepository(_tmdbContext);
            var userFaker = new User(userdto.Name, userdto.Email, userdto.Password, userdto.Birthday);
            string profileName = new Faker().Person.FirstName;
            userFaker.AddProfile(Profile.CreateGuestProfile(profileName));
            User savedUser = await userRepository.Create(userFaker);

            //Action
            await userRepository.Update(savedUser);

            //Assert
            Assert.NotEqual(0, savedUser.Id);
            Assert.Equal(userFaker.Name, savedUser.Name);
            Assert.Equal(userFaker.Email, savedUser.Email);
            Assert.Contains(savedUser.Profiles, p => p.TypeProfile == (int)ETypeProfile.Guest);
        }


        private async Task StartingDatabase()
        {
            _tmdbContext = _serviceProvider.GetService<TmdbContext>();
            await _tmdbContext.Database.EnsureCreatedAsync();
        }

        public void Dispose()
        {
            _tmdbContext.Database.EnsureDeleted();
        }
    }
}
