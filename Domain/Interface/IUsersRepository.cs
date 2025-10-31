using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface IUsersRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<List<User>> GetAll();
        Task<User?> Add(User user);
        Task<User?> Update(User user);
    }
}
