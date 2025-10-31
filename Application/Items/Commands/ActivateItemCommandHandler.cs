using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Commands
{
    public class ActivateItemCommandHandler(IItemsRepository itemsRepository)
    {
        public async Task<int> Handle(ActivateItemCommand command)
        {
            var existingItem = await itemsRepository.GetById(command.Id) ?? throw new Exception("Item not found");
            existingItem.IsActive = true;
            var activatedItem = await itemsRepository.Delete(existingItem);
            return activatedItem == null ? throw new Exception("Failed to activate item") : activatedItem.Id;
        }
    }
}
