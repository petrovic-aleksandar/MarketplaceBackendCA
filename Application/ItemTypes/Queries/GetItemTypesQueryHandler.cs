using Marketplace.Domain.Interface;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.ItemTypes.Queries
{
    public class GetItemTypesQueryHandler(IItemTypesRepository itemTypesRepository)
    {
        public async Task<List<ItemType>> Handle(GetItemTypesQuery query) 
        {
            return await itemTypesRepository.GetItemTypes();
        }
    }
}
