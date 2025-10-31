using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Commands
{
    public class DeleteItemCommandHandler(IItemsRepository itemsRepository)
    {
        public async Task<int> Handle(DeleteItemCommand command)
        {
            var existingItem = await itemsRepository.GetById(command.Id) ?? throw new Exception("Item not found");
            existingItem.IsDeleted = true;
            var deletedItem = await itemsRepository.Delete(existingItem);
            return deletedItem == null ? throw new Exception("Failed to delete item") : deletedItem.Id;
        }
    }
}
