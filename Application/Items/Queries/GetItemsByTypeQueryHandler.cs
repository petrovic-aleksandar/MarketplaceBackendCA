using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Queries
{
    public class GetItemsByTypeQueryHandler(IItemsRepository itemsRepository, IItemTypesRepository itemTypesRepository, IImagesRepository imagesRepository)
    {
        public async Task<List<ItemResponse>> Handle(GetItemsByTypeQuery query)
        {
            var type = await itemTypesRepository.GetById(query.TypeId) ?? throw new Exception("Item type not found");
            List<Item> items = await itemsRepository.GetByType(type);
            Dictionary<int, Image?> map = [];
            items.ForEach(item => map.Add(item.Id, imagesRepository.GetFrontImageForItem(item)));
            List<ItemResponse> responses = [];
            items.ForEach(item => responses.Add(ItemResponse.FromItem(item)));
            responses.ForEach(resp => resp.FrontImage = map.GetValueOrDefault(resp.Id) != null ? ImageResponse.FromImage(map.GetValueOrDefault(resp.Id)!) : null);
            return responses;
        }
    }
}
