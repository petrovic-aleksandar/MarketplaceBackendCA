using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;

namespace Marketplace.Application.Transfers.Queries
{
    public class GetTransfersByUserQueryHandler(ITransfersRepository transfersRepository, IUsersRepository usersRepository)
    {
        public async Task<List<TransferResponse>> Handle(GetTransfersByUserQuery query) 
        {
            var user = await usersRepository.GetById(query.UserId) ?? throw new Exception("User not found");
            List<Transfer> transfers = await transfersRepository.GetByUser(user);
            List<TransferResponse> responses = [];
            transfers.ForEach(transfer => responses.Add(TransferResponse.FromTransfer(transfer)));
            return responses;
        }
    }
}
