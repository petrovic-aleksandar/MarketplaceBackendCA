using Marketplace.Application.Models;
using Marketplace.Application.Utilities;
using Marketplace.Domain.Interface;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Application.Auth.Command
{
    public class RefreshTokenCommandHandler(IUsersRepository usersRepository, IConfiguration configuration)
    {
        public async Task<TokenResponse?> Handle(RefreshTokenCommand command)
        {
            //if access token is expired but valid?

            TokensUtil tokensUtil = new(usersRepository, configuration);
            var user = await tokensUtil.ValidateRefreshToken(command.userId, command.RefreshToken) ?? throw new Exception("Invalid refresh token");
            return await tokensUtil.CreateTokenResponse(user);
        }
    }
}
