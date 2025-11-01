using Marketplace.Application.Models;
using Marketplace.Application.Users.Commands;
using Marketplace.Application.Users.Queries;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(
        GetUserByIdQueryHandler getUserByIdQueryHandler,
        GetAllUsersQueryHandler getAllUsersQueryHandler,
        AddUserCommandHandler addUserCommandHandler,
        UpdateUserCommandHandler updateUserCommandHandler,
        DeactivateUserCommandHandler deactivateUserCommandHandler,
        ActivateUserCommandHandler activateUserCommandHandler
        ) : ControllerBase
    {

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            return Ok(await getUserByIdQueryHandler.Handle(new GetUserByIdQuery(id)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAll()
        {
            return Ok(await getAllUsersQueryHandler.Handle(new GetAllUsersQuery()));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<User>> Add(AddUserCommand command)
        {
            return Ok(await addUserCommandHandler.Handle(command));
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, UpdateUserCommand command)
        {
            return Ok(await updateUserCommandHandler.Handle(command with { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("deactivate/{id}")]
        public async Task<ActionResult<User>> Deactivate(int id)
        {
            return Ok(await deactivateUserCommandHandler.Handle(new DeactivateUserCommand(id)));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("activate/{id}")]
        public async Task<ActionResult<User>> Activate(int id)
        {
            return Ok(await activateUserCommandHandler.Handle(new ActivateUserCommand(id)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("roles")]
        public List<string> GetRoles()
        {
            List<UserRole> roles = [.. Enum.GetValues<UserRole>()];
            List<string> result = [];
            roles.ForEach(x => result.Add(x.ToString()));
            return result;
        }
    }
}
