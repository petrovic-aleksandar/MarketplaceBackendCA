namespace Marketplace.Application.Images.Commands
{
    public record DeleteImageCommand
    {
        public int Id { get; set; }

        public DeleteImageCommand(int id)
        {
            Id = id;
        }
    }
}
