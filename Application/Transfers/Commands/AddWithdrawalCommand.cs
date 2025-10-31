namespace Marketplace.Application.Transfers.Commands
{
    public class AddWithdrawalCommand
    {
        public int BuyerId { get; set; }
        public double Amount { get; set; }
    }
}
