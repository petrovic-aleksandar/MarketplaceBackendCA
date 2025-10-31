using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class TransfersRepository(MarketplaceDbContext context)
    {
        public async Task<List<Transfer>> getByUser(User user) 
        {
            return await context.Transfer.Where(t => t.Buyer != null && t.Buyer.Id == user.Id || t.Seller != null && t.Seller.Id == user.Id).ToListAsync();
        }

        public async Task<Transfer> AddTransfer(Transfer transfer)
        {
            context.Transfer.Add(transfer);
            await context.SaveChangesAsync();
            return transfer;
        }
    }
}
