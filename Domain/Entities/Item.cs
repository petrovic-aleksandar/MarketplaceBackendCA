namespace Marketplace.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public required ItemType Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Createtime { get; set; }
        public required User Seller { get; set; }
        public ICollection<Image> Images { get; } = new List<Image>();

    }
}
