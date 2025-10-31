namespace Marketplace.Application.Transfers.Commands
{
    public class AddPaymentCommand
    {
        public int SellerId { get; set; }
        public decimal Amount { get; set; }
    }
}
