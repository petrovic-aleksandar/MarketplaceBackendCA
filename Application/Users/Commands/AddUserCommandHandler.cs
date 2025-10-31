using Marketplace.Application.Utilities;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Commands
{
    public class AddUserCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(AddUserCommand command) 
        {
            User user = new()
            {
                Username = command.Username,
                Password = "",
                Salt = HashingUtil.GenerateSalt(),
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Balance = 0.0,
                Role = Enum.Parse<UserRole>(command.Role),
                IsActive = true
            };

            user.Password = HashingUtil.HashPassword(command.Password, user.Salt);

            var addedUser = await usersRepository.Add(user);
            return addedUser == null ? throw new Exception("Failed to add user") : addedUser.Id;
        }
    }
}
