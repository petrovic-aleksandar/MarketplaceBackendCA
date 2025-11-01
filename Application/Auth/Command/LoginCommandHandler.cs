using Marketplace.Application.Models;
using Marketplace.Application.Utilities;
using Marketplace.Domain.Interface;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Application.Auth.Command
{
    public class LoginCommandHandler(IUsersRepository usersRepository, IConfiguration configuration)
    {
        public async Task<TokenResponse?> Handle(LoginCommand command) 
        {
            var user = await usersRepository.GetByUsername(command.Username) ?? throw new Exception("User not found");
            if (!HashingUtil.VerifyPassword(command.Password, user.Password)) throw new Exception("Invalid credentials");
            TokensUtil tokensUtil = new(usersRepository, configuration);
            return await tokensUtil.CreateTokenResponse(user);
        }
    }
}
