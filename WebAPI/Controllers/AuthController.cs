using Marketplace.Application.Auth.Command;
using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
            LoginCommandHandler loginCommandHandler,
            RefreshTokenCommandHandler refreshTokenCommandHandler,
            RegisterCommandHandler registerCommandHandler,
            RevokeTokenCommandHandler revokeTokenCommandHandler
        ) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> Login(LoginCommand command)
        {
            return Ok(await loginCommandHandler.Handle(command));
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterCommand command)
        {
            return Ok(await registerCommandHandler.Handle(command));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponse>> RefreshToken(RefreshTokenCommand command)
        {
            return Ok(await refreshTokenCommandHandler.Handle(command));
        }

        [HttpPost("revoke-token/{userId}")]
        public async Task<ActionResult<string>> RevokeToken(int userId)
        {
            return Ok(await revokeTokenCommandHandler.Handle(new RevokeTokenCommand(userId)));
        }
    }
}
