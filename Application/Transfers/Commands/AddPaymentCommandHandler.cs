using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Transfers.Commands
{
    public class AddPaymentCommandHandler(ITransfersRepository transfersRepository, IUsersRepository usersRepository)
    {
        public async Task<int> Handle(AddPaymentCommand command)
        {
            var seller = await usersRepository.GetById(command.SellerId) ?? throw new Exception("Seller not found");

            Transfer transfer = new()
            {
                Amount = command.Amount,
                Time = DateTime.UtcNow,
                Type = Domain.Enums.TransferType.Payment,
                Buyer = null,
                Seller = seller,
                Item = null
            };

            seller.Balance += command.Amount;
            _ = await usersRepository.Update(seller) ?? throw new Exception("Failed to update seller balance");

            var addedTransfer = await transfersRepository.AddTransfer(transfer) ?? throw new Exception("Failed to add transfer");
            return addedTransfer.Id;
        }
    }
}
