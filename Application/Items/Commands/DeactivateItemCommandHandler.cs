using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Commands
{
    public class DeactivateItemCommandHandler(IItemsRepository itemsRepository)
    {
        public async Task<int> Handle(DeactivateItemCommand command)
        {
            var existingItem = await itemsRepository.GetById(command.Id) ?? throw new Exception("Item not found");
            existingItem.IsActive = false;
            var deactivatedItem = await itemsRepository.Delete(existingItem);
            return deactivatedItem == null ? throw new Exception("Failed to deactivate item") : deactivatedItem.Id;
        }
    }
}
