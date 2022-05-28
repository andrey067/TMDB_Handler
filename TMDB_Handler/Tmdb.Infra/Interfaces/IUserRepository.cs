using Tmdb.Domain.Entities;

namespace Tmdb.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int Id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Remove(int Id);
        Task<List<User>> GetAll();
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
    }
}