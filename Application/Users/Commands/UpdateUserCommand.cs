namespace Marketplace.Application.Users.Commands
{
    public record UpdateUserCommand
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool UpdatePassword { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Role { get; set; }
    }
}
