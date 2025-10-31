using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Commands
{
    public class AddImageCommandHandler(IImagesRepository imagesRepository, IItemsRepository itemsRepository)
    {
        public async Task<int> Handle(AddImageCommand command) 
        {
            var item = await itemsRepository.GetById(command.ItemId) ?? throw new Exception("Item not found");

            var folder = Path.Combine("Images", item.Id.ToString());
            var fullPath = Path.Combine(folder, command.ImageName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using var stream = new FileStream(fullPath, FileMode.Create);
                command.Image.CopyTo(stream);
            }
            catch (Exception)
            {
                throw new Exception("Error while saving the image");
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
