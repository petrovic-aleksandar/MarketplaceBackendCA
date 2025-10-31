using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public double Balance { get; set; }
        public required string Role { get; set; }
        public bool Active { get; set; }

        public static UserResponse FromUser(User user)
        {
            return new()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Balance = user.Balance,
                Role = user.Role.ToString(),
                Active = user.IsActive
            };
        }
    }
}
