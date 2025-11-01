namespace Marketplace.Application.Auth.Command
{
    public record LoginCommand
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
