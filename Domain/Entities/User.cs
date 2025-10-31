using Marketplace.Domain.Enums;

namespace Marketplace.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Salt { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone {  get; set; }
        public required double Balance { get; set; }
        public required UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}
