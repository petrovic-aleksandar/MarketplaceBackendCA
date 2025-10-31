using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Transfers.Commands
{
    public class AddWithdrawalCommandHandler(ITransfersRepository transfersRepository, IItemsRepository itemsRepository, IUsersRepository usersRepository)
    {
        public async Task<int> Handle(AddWithdrawalCommand command)
        {
            var buyer = await usersRepository.GetById(command.BuyerId) ?? throw new Exception("Buyer not found");
            Transfer transfer = new()
            {
                Amount = command.Amount,
                Time = DateTime.UtcNow,
                Type = Domain.Enums.TransferType.Withdrawal,
                Buyer = buyer,
                Seller = null,
                Item = null
            };
            var addedTransfer = await transfersRepository.AddTransfer(transfer);
            return addedTransfer == null ? throw new Exception("Failed to add transfer") : addedTransfer.Id;
        }
    }
}
