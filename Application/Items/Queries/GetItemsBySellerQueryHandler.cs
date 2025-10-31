using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Items.Queries
{
    public class GetItemsBySellerQueryHandler(IItemsRepository itemsRepository, IUsersRepository usersRepository)
    {
        public async Task<List<ItemResponse>> Handle(GetItemsBySellerQuery query) 
        {
            var seller = await usersRepository.GetById(query.SellerId) ?? throw new Exception("Seller not found");
            List<Item> items = await itemsRepository.GetBySeller(seller);
            List<ItemResponse> response = [];
            items.ForEach(item => response.Add(ItemResponse.FromItem(item)));
            return response;
        }
    }
}
