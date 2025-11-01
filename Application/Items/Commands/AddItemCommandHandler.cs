using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;


namespace Marketplace.Application.Items.Commands
{
    public class AddItemCommandHandler(IItemsRepository itemsRepository, IUsersRepository usersRepository, IItemTypesRepository itemTypesRepository)
    {
        public async Task<int> Handle(AddItemCommand command)
        {
            var seller = usersRepository.GetById(command.SellerId).Result ?? throw new Exception("Seller not found");
            var itemType = itemTypesRepository.GetById(command.TypeId).Result ?? throw new Exception("Item type not found");

            var item = new Item
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Type = itemType,
                Seller = seller,
                IsActive = true
            };

            var addedItem = await itemsRepository.Add(item);
            return addedItem == null ? throw new Exception("Failed to add item") : addedItem.Id;
        }
    }
}
