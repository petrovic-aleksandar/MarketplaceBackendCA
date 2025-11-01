namespace Marketplace.Application.Users.Commands
{
    public record ChangeUserBalanceCommand
    {
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}
