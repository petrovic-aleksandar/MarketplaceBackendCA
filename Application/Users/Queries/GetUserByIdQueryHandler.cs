using Marketplace.Application.Models;
using Marketplace.Application.Transfers.Queries;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Queries
{
    public class GetUserByIdQueryHandler(IUsersRepository usersRepository)
    {
        public async Task<UserResponse> Handle(GetUserByIdQuery query) 
        {
            var user = await usersRepository.GetById(query.Id) ?? throw new Exception("User not found");
            return UserResponse.FromUser(user);
        }
    }
}
