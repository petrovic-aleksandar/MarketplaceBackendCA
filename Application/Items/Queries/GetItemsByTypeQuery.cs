namespace Marketplace.Application.Items.Queries
{
    public class GetItemsByTypeQuery(int typeId)
    {
        public int TypeId { get; set; } = typeId;
    }
}
