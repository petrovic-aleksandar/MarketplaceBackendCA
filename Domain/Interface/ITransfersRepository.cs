using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface ITransfersRepository
    {
        Task<List<Transfer>> GetByUser(User user);
        Task<Transfer> AddTransfer(Transfer transfer);
    }
}
