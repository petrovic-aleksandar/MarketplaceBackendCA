namespace Marketplace.Application.Transfers.Commands
{
    public class AddPaymentCommand
    {
        public int SellerId { get; set; }
        public double Amount { get; set; }
    }
}
