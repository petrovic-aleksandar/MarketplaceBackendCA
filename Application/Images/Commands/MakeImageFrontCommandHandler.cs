using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Commands
{
    public class MakeImageFrontCommandHandler(IImagesRepository imagesRepository)
    {
        public async Task<int> Handle(MakeImageFrontCommand command)
        {
            var image = await imagesRepository.GetById(command.Id) ?? throw new Exception("Image not found");
            if (image.IsFront) throw new Exception("Image is already front");

            var frontImage = await imagesRepository.GetFrontImageForItemAsync(image.Item);
            frontImage!.IsFront = false;
            image.IsFront = true;
            _ = await imagesRepository.Update(frontImage) ?? throw new Exception("Front image not updated");
            var updatedNewImg = await imagesRepository.Update(image);
            return updatedNewImg == null ? throw new Exception("Front image not updated") : updatedNewImg.Id;
        }
    }
}
