namespace Marketplace.Application.Items.Commands
{
    public class UpdateItemCommand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public required int TypeId { get; set; }
        public required int SellerId { get; set; }
    }
}
