using Microsoft.EntityFrameworkCore;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Context;
using Tmdb.Infra.Interfaces;

namespace Tmdb.Infra.Repository
{
    //TODO - coloca no baseRepository metodos iguais
    public class AutenticationRepository : IAutenticationRepository
    {
        private DbSet<User> _userDbSet;
        private readonly AuthenticationContext _autenticationContext;

        public AutenticationRepository(AuthenticationContext context)
        {
            _autenticationContext = context;
            _userDbSet = _autenticationContext.Set<User>();
        }
        public async Task<User> Create(User user)
        {
            _userDbSet.Add(user);
            await _autenticationContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userDbSet.Where(x => x.Email.ToLower() == email.ToLower())
            .AsNoTracking().ToListAsync();
            return user.FirstOrDefault();
        }

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
