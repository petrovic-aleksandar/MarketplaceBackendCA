namespace Marketplace.Application.Items.Commands
{
    public class ChangeItemOwnerCommand
    {
        public int Id { get; set; }
        public int NewOwnerId { get; set; }
    }
}
