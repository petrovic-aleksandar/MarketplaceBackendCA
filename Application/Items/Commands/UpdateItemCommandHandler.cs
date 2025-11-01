using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Commands
{
    public class UpdateItemCommandHandler(IItemsRepository itemsRepository, IUsersRepository usersRepository, IItemTypesRepository itemTypesRepository)
    {
        public async Task<int> Handle(UpdateItemCommand command)
        {
            var existingItem = await itemsRepository.GetById(command.Id) ?? throw new Exception("Item not found");
            var seller = usersRepository.GetById(command.SellerId).Result ?? throw new Exception("Seller not found");
            var itemType = itemTypesRepository.GetById(command.TypeId).Result ?? throw new Exception("Item type not found");

            existingItem.Name = command.Name;
            existingItem.Description = command.Description;
            existingItem.Price = command.Price;
            existingItem.Type = itemType;
            existingItem.Seller = seller;

            var updatedItem = await itemsRepository.Update(existingItem);
            return updatedItem == null ? throw new Exception("Failed to add item") : updatedItem.Id;
        }
    }
}
