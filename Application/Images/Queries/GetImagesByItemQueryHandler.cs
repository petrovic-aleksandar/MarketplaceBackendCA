using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Queries
{
    public class GetImagesByItemQueryHandler(IImagesRepository imagesRepository, IItemsRepository itemsRepository)
    {
        public async Task<List<ImageResponse>> Handle(GetImagesByItemQuery query) 
        {
            var item = await itemsRepository.GetById(query.ItemId) ?? throw new Exception("Item not found");
            List<Image> images = await imagesRepository.GetByItem(item);
            List<ImageResponse> resp = [];
            images.ForEach(x => resp.Add(ImageResponse.FromImage(x)));
            return resp;
        }
    }
}
