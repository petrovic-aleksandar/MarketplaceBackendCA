namespace Marketplace.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public required string Path { get; set; }
        public required Item Item { get; set; }
        public bool IsFront { get; set; }
    }
}
