namespace Marketplace.Application.Items.Commands
{
    public record DeactivateItemCommand
    {
        public int Id { get; set; }

        public DeactivateItemCommand(int id)
        {
            Id = id;
        }
    }
}