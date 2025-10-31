using Marketplace.Application.Models;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Queries
{
    internal class GetFrontImageForItemQueryHandler(IImagesRepository imagesRepository, IItemsRepository itemsRepository)
    {
        public async Task<ImageResponse> Handle(GetFrontImageForItemQuery query) 
        {
            var item = await itemsRepository.GetById(query.ItemId) ?? throw new Exception("Item not found");
            var image = await imagesRepository.GetFrontImageForItem(item) ?? throw new Exception("No front image for item found");
            return ImageResponse.FromImage(image);
        }
    }
}
