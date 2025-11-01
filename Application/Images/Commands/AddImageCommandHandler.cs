using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Commands
{
    public class AddImageCommandHandler(IImagesRepository imagesRepository, IItemsRepository itemsRepository, IFileService fileService)
    {
        public async Task<int> Handle(AddImageCommand command) 
        {
            var item = await itemsRepository.GetById(command.ItemId) ?? throw new Exception("Item not found");

            var folder = Path.Combine("Images", item.Id.ToString());
            var fullPath = Path.Combine(folder, command.ImageName);
            try 
            {
                fileService.SaveFile(fullPath, command.Image);
            }
            catch (Exception)
            {
                throw;
            }
            var frontImage = await imagesRepository.GetFrontImageForItem(item);
            Image image = new()
            {
                Path = command.ImageName,
                Item = item,
                IsFront = frontImage is null
            };
            var addedImage = await imagesRepository.Add(image);
            return addedImage == null ? throw new Exception("Failed to add image") : addedImage.Id;
        }
    }
}
