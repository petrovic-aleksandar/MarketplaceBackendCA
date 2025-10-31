using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Commands
{
    public class ActivateUserCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(ActivateUserCommand command) 
        {
            var user = usersRepository.GetById(command.Id).Result ?? throw new Exception("User not found");
            user.IsActive = true;
            var updatedUser = await usersRepository.Update(user);
            return updatedUser == null ? throw new Exception("Failed to activate user") : updatedUser.Id;
        }  
    }
}
