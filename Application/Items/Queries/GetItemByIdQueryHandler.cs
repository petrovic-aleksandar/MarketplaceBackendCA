using Marketplace.Application.Models;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Queries
{
    public class GetItemByIdQueryHandler(IItemsRepository itemsRepository)
    {
        public async Task<ItemResponse> Handle(GetItemByIdQuery query) 
        {
            var item = await itemsRepository.GetById(query.Id) ?? throw new Exception("Item not found");
            return ItemResponse.FromItem(item);
        }
    }
}
