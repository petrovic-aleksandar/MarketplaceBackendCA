using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Users.Queries
{
    public class GetAllUsersQueryHandler(IUsersRepository usersRepository)
    {
        public async Task<List<UserResponse>> Handle(GetAllUsersQuery query) 
        {
            List<User> users = await usersRepository.GetAll();
            List<UserResponse> responses = [];
            users.ForEach(user => responses.Add(UserResponse.FromUser(user)));
            return responses;
        }
    }
}
