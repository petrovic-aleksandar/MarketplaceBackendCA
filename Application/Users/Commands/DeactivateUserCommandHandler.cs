using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Commands
{
    public class DeactivateUserCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(DeactivateUserCommand command)
        {
            var user = usersRepository.GetById(command.Id).Result ?? throw new Exception("User not found");
            user.IsActive = false;
            var updatedUser = await usersRepository.Update(user);
            return updatedUser == null ? throw new Exception("Failed to deactivate user") : updatedUser.Id;
        }
    }
}
