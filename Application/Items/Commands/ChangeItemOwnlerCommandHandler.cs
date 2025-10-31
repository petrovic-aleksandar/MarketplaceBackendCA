using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Commands
{
    public class ChangeItemOwnlerCommandHandler(IItemsRepository itemsRepository, IUsersRepository usersRepository)
    {
        public async Task<int> Handle(ChangeItemOwnerCommand command)
        {
            var item = await itemsRepository.GetById(command.Id) ?? throw new Exception("Item not found");
            var newOwner = await usersRepository.GetById(command.NewOwnerId) ?? throw new Exception("New owner not found");

            item.Seller = newOwner;
            item.IsActive = false;
            var updatedItem = await itemsRepository.Update(item);
            return updatedItem == null ? throw new Exception("Failed to change item owner") : updatedItem.Id;
        }
    }
}
