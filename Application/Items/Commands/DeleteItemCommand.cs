namespace Marketplace.Application.Items.Commands
{
    public record DeleteItemCommand
    {
        public int Id { get; set; }

        public DeleteItemCommand(int id)
        {
            Id = id;
        }
    }
}
