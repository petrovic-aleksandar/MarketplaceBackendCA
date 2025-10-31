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

            var addedTransfer = await transfersRepository.AddTransfer(transfer);
            return addedTransfer == null ? throw new Exception("Failed to add transfer") : addedTransfer.Id;
        }
    }
}
