using Tmdb.Domain.Entities;

namespace Tmdb.Infra.Interfaces
{
    public interface IAutenticationRepository
    {
        Task<User> Create(User user);
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
    }
}
