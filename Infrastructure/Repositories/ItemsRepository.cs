using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marketplace.Infrastructure.Repositories
{
    public class ItemsRepository(MarketplaceDbContext context) : IItemsRepository
    {
        public async Task<Item?> GetById(int id)
        {
            return await context.Item.Include(x => x.Type).Include(x => x.Seller).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetBySeller(User seller)
        {
            return await context.Item.Include(x => x.Type).Include(x => x.Seller).Where(x => x.Seller == seller).ToListAsync();
        }

        public async Task<List<Item>> GetByType(ItemType type)
        {
            return await context.Item.Include(x => x.Seller).Include(x => x.Type).Where(x => x.Type == type && x.IsDeleted == false && x.IsActive == true).ToListAsync();
        }

        public async Task<Item?> Add(Item item)
        {
            context.Item.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> Update(Item item)
        {
            context.Item.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> Delete(Item item)
        {
            item.IsDeleted = true;
            context.Item.Update(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
