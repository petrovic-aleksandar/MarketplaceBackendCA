using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface IItemTypesRepository
    {
        Task<ItemType?> GetById(int id);
        Task<List<ItemType>> getItemTypes();
    }
}
