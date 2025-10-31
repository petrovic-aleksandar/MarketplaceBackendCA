using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public required ItemType Type { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public required UserResponse Seller { get; set; }
        public Image? FrontImage { get; set; }

        public static ItemResponse FromItem(Item item)
        {
            return new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Type = item.Type,
                Active = item.IsActive,
                Deleted = item.IsDeleted,
                CreatedAt = item.Createtime,
                Seller = UserResponse.FromUser(item.Seller)
            };
        }
    }
}
