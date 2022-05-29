using Microsoft.EntityFrameworkCore;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Context;
using Tmdb.Infra.Interfaces;

namespace Tmdb.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _userDbSet;
        private readonly TmdbContext _context;

        public UserRepository(TmdbContext context)
        {
            _context = context;
            _userDbSet = _context.Set<User>();
        }

        public async Task<User> Create(User user)
        {
            _userDbSet.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userDbSet.Where(x => x.Email.ToLower() == email.ToLower())
            .AsNoTracking().ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<User> GetUser(int Id)
        {
            var user = await _userDbSet.Where(x => x.Id == Id).ToListAsync();
            return user.FirstOrDefault();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(User user)
        {
            _userDbSet.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
