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

            if (item.Seller.Id == buyer.Id) throw new Exception("It's not possible to purchase your own item");
            if (!item.IsActive) throw new Exception("Item is not available for purchase");
            if (buyer.Balance < item.Price) throw new Exception("Not enough money to purchase this item");

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
