namespace Marketplace.Application.Users.Commands
{
    public record RegisterUserCommand
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
