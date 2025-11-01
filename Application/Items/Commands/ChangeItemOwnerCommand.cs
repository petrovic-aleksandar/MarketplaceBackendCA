namespace Marketplace.Application.Items.Commands
{
    public record ChangeItemOwnerCommand
    {
        public int Id { get; set; }
        public int NewOwnerId { get; set; }
    }
}
