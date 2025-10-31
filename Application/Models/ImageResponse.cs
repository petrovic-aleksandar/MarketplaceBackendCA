using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    public class ImageResponse
    {
        public int Id { get; set; }
        public required string Path { get; set; }
        public bool Front { get; set; }

        public static ImageResponse FromImage(Image image)
        {
            return new()
            {
                Id = image.Id,
                Path = image.Path,
                Front = image.IsFront
            };
        }
    }
}
