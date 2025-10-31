namespace Marketplace.Domain.Entities
{
    public class ItemType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImagePath { get; set; }
    }
}
