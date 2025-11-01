namespace Marketplace.Application.Users.Commands
{
    public record ActivateUserCommand
    {
        public int Id { get; set; }

        public ActivateUserCommand(int id)
        {
            Id = id;
        }
    }
}
