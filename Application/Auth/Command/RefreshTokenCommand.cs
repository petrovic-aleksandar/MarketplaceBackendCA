namespace Marketplace.Application.Auth.Command
{
    public record RefreshTokenCommand
    {
        public int userId { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
