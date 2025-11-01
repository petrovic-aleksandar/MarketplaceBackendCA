namespace Marketplace.Application.Transfers.Queries
{
    public class GetTransfersByUserQuery
    {
        public int UserId { get; set; }

        public GetTransfersByUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
