using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class ItemTypesRepository(MarketplaceDbContext context)
    {
        public async Task<ItemType?> GetById(int id)
        {
            return await context.ItemType.FindAsync(id);
        }

        public async Task<List<ItemType>> getItemTypes()
        {
            return await context.ItemType.ToListAsync();
        }
    }
}
