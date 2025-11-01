using Marketplace.Application.Utilities;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Auth.Command
{
    public class RegisterCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(RegisterCommand command)
        {
            var existingUser = await usersRepository.GetByUsername(command.Username);
            if (existingUser != null) throw new Exception("Username already exists");

            User newUser = new()
            {
                Username = command.Username,
                Password = "",
                Salt = HashingUtil.GenerateSalt(),
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Balance = 0.0,
                IsActive = true,
                Role = UserRole.User
            };

            newUser.Password = HashingUtil.HashPassword(command.Password, newUser.Salt);

            var addedUser = await usersRepository.Add(newUser);
            return addedUser == null ? throw new Exception("Failed to register user") : addedUser.Id;
        }
    }
}
