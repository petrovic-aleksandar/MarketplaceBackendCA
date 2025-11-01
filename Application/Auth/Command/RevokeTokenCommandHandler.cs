using Marketplace.Domain.Interface;

namespace Marketplace.Application.Auth.Command
{
    public class RevokeTokenCommandHandler(IUsersRepository usersRepository)
    {
        public async Task<int> Handle(RevokeTokenCommand command) 
        {
            var user = await usersRepository.GetById(command.UserId) ?? throw new Exception("User not found");

            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;
            var updatedUser = await usersRepository.Update(user);
            return updatedUser == null ? throw new Exception("Revoke token failed") : updatedUser.Id;
        }
    }
}
