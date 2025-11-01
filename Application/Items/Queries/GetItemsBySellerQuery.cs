namespace Marketplace.Application.Items.Queries
{
    public class GetItemsBySellerQuery(int sellerId)
    {
        public int SellerId { get; set; } = sellerId;
    }
}
