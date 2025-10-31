using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface IItemsRepository
    {
        Task<Item?> GetById(int id);
        Task<List<Item>> GetBySeller(User seller);
        Task<List<Item>> GetByType(ItemType type);
        Task<Item?> Add(Item item);
        Task<Item?> Update(Item item);
        Task<Item?> Delete(Item item);
    }
}
