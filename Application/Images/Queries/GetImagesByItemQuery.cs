namespace Marketplace.Application.Images.Queries
{
    public record GetImagesByItemQuery
    {
        public int ItemId { get; set; }

        public GetImagesByItemQuery(int itemId)
        {
            ItemId = itemId;
        }
    }
}
