using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Transfers.Commands
{
    public class PurchaseItemCommandHandler(ITransfersRepository transfersRepository, IItemsRepository itemsRepository, IUsersRepository usersRepository)
    {
        public async Task<int> Handle(PurchaseItemCommand command)
        {
            var item = await itemsRepository.GetById(command.ItemId) ?? throw new Exception("Item not found");
            var buyer = await usersRepository.GetById(command.BuyerId) ?? throw new Exception("Buyer not found");

            Transfer transfer = new()
            {
                Amount = item.Price,
                Time = DateTime.UtcNow,
                Type = Domain.Enums.TransferType.Purchase,
                Buyer = buyer,
                Seller = item.Seller,
                Item = item
            };

            var addedTransfer = await transfersRepository.AddTransfer(transfer);

            item.Seller = buyer;
            item.IsActive = false;
            _ = await itemsRepository.Update(item) ?? throw new Exception("Failed to change item owner");

            return addedTransfer == null ? throw new Exception("Failed to add transfer") : addedTransfer.Id;
        }
    }
}
