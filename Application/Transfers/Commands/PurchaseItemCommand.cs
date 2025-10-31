using System.Net;

namespace Marketplace.Application.Transfers.Commands
{
    public class PurchaseItemCommand
    {
        public int ItemId { get; set; }
        public int BuyerId { get; set; }
    }
}
