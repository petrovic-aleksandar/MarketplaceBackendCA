using Marketplace.Application.Utilities;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Commands
{
    public class UpdateUserCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(UpdateUserCommand command)
        {
            var user = usersRepository.GetById(command.Id).Result ?? throw new Exception("User not found");

            if (command.UpdatePassword)
            {
                user.Salt = HashingUtil.GenerateSalt();
                user.Password = HashingUtil.HashPassword(command.Password, user.Salt);
            }

            user.Username = command.Username;
            user.Name = command.Name;
            user.Email = command.Email;
            user.Phone = command.Phone;
            user.Role = Enum.Parse<UserRole>(command.Role);

            var updatedUser = await usersRepository.Update(user);
            return updatedUser == null ? throw new Exception("Failed to update user") : updatedUser.Id;
        }
    }
}
