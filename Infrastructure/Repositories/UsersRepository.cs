using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories 
{
    public class UsersRepository(MarketplaceDbContext context) : IUsersRepository
    {
        public async Task<User?> GetById(int id)
        {
            return await context.User.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await context.User.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<User>> GetAll()
        {
            return await context.User.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<User?> Add(User user)
        {
            context.User.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Update(User user)
        {
            context.User.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
