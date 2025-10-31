using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    public class TransferResponse
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public required string Type { get; set; }
        public string? Buyer { get; set; }
        public string? Seller { get; set; }
        public string? Item { get; set; }

        public static TransferResponse FromTransfer(Transfer transfer)
        {
            return new()
            {
                Id = transfer.Id,
                Amount = transfer.Amount,
                Time = transfer.Time,
                Type = transfer.Type.ToString(),
                Buyer = transfer.Buyer?.Username,
                Seller = transfer.Seller?.Username,
                Item = transfer.Item?.Name
            };
        }
    }
}
