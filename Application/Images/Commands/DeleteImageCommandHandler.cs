using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Commands
{
    public class DeleteImageCommandHandler(IImagesRepository imagesRepository)
    {
        public async Task Handle(DeleteImageCommand command) 
        {
            var image = await imagesRepository.GetById(command.Id) ?? throw new Exception("Image not found");
            try
            {
                await imagesRepository.Delete(image);
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete item");
            }

            var folder = Path.Combine("Images", image.Item.Id.ToString());
            var filePath = Path.Combine(folder, image.Path);
            try 
            {
                File.Delete(filePath);
            }
            catch(Exception)
            {
                throw new Exception("Error while deleting from the file system");
            }
            return;
        }
    }
}
