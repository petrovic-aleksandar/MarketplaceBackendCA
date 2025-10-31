using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    internal class ItemTypeResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImagePath { get; set; }

        public ItemTypeResponse FromItemType(ItemType itemType)
        {
            return new() {
                Id = itemType.Id,
                Name = itemType.Name,
                Description = itemType.Description,
                ImagePath = itemType.ImagePath
            };
        }
    }
}
