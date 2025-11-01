namespace Marketplace.Application.Users.Commands
{
    public record DeactivateUserCommand
    {
        public int Id { get; set; }

        public DeactivateUserCommand(int id)
        {
            Id = id;
        }
    }
}
