namespace Marketplace.Application.Items.Commands
{
    public record ActivateItemCommand
    {
        public int Id { get; set; }

        public ActivateItemCommand(int id)
        {
            Id = id;
        }
    }
}
