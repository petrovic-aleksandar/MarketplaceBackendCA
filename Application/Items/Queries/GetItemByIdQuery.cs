namespace Marketplace.Application.Items.Queries
{
    public class GetItemByIdQuery(int id)
    {
        public int Id { get; set; } = id;
    }
}
