using Marketplace.Domain.Enums;

namespace Marketplace.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public required TransferType Type { get; set; }
        public User? Buyer { get; set; }
        public User? Seller { get; set; }
        public Item? Item { get; set; }

    }
}
