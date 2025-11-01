using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class TransfersRepository(MarketplaceDbContext context) : ITransfersRepository
    {
        public async Task<List<Transfer>> GetByUser(User user) 
        {
            return await context.Transfer.Where(t => t.Buyer != null && t.Buyer.Id == user.Id || t.Seller != null && t.Seller.Id == user.Id).Include(t => t.Buyer).Include(t => t.Seller).Include(t => t.Item).OrderByDescending(t => t.Id).ToListAsync();
        }

        public async Task<Transfer> AddTransfer(Transfer transfer)
        {
            context.Transfer.Add(transfer);
            await context.SaveChangesAsync();
            return transfer;
        }
    }
}
