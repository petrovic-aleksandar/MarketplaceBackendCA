using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class ItemTypesRepository(MarketplaceDbContext context) : IItemTypesRepository
    {
        public async Task<ItemType?> GetById(int id)
        {
            return await context.ItemType.FindAsync(id);
        }

        public async Task<List<ItemType>> GetItemTypes()
        {
            return await context.ItemType.ToListAsync();
        }
    }
}
