namespace Marketplace.Application.Auth.Command
{
    public record RevokeTokenCommand
    {
        public int UserId { get; set; }

        public RevokeTokenCommand(int userId)
        {
            UserId = userId;
        }
    }
}
