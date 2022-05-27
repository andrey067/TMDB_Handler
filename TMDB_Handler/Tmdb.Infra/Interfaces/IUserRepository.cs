namespace Tmdb.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int Id);
        Task<User> Create(CreateUserCommand createUserCommand);
        Task<User> Update(UpdateUserCommand updateUserCommand);
        Task Remove(int id);
        Task<List<User>> GetAll();
        Task<Users> GetByEmail(string email);
        Task<List<Users>> SearchByEmail(string email);
    }
}