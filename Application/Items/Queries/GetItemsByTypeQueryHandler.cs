using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Queries
{
    public class GetItemsByTypeQueryHandler(IItemsRepository itemsRepository, IItemTypesRepository itemTypesRepository)
    {
        public async Task<List<ItemResponse>> Handle(GetItemsByTypeQuery query)
        {
            var type = await itemTypesRepository.GetById(query.TypeId) ?? throw new Exception("Item type not found");
            List<Item> items = await itemsRepository.GetByType(type);
            List<ItemResponse> responses = [];
            items.ForEach(item => responses.Add(ItemResponse.FromItem(item)));
            return responses;
        }
    }
}
