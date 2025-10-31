using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface ITransfersRepository
    {
        Task<List<Transfer>> getByUser(User user);
        Task<Transfer> AddTransfer(Transfer transfer);
    }
}
