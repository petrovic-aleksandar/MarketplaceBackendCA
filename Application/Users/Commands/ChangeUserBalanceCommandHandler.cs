using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Commands
{
    public class ChangeUserBalanceCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(ChangeUserBalanceCommand command) 
        {
            var user = usersRepository.GetById(command.Id).Result ?? throw new Exception("User not found");
            user.Balance += command.Amount;
            var updatedUser = await usersRepository.Update(user);
            return updatedUser == null ? throw new Exception("Failed to change user balance") : updatedUser.Id;
        }
    }
}
