using Marketplace.Application.Models;
using Marketplace.Application.Transfers.Commands;
using Marketplace.Application.Transfers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController(
        GetTransfersByUserQueryHandler getTransfersByUserQueryHandler,
        AddPaymentCommandHandler addPaymentCommandHandler,
        AddWithdrawalCommandHandler addWithdrawalCommandHandler,
        PurchaseItemCommandHandler purchaseItemCommandHandler
        ) : ControllerBase
    {

        [HttpGet("byUserId/{userId}")]
        public async Task<ActionResult<List<TransferResponse>>> GetByUserId(int userId)
        {
            return Ok(await getTransfersByUserQueryHandler.Handle(new GetTransfersByUserQuery(userId)));
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<TransferResponse>> AddPurchase(PurchaseItemCommand command)
        {
            return Ok(await purchaseItemCommandHandler.Handle(command));
        }

        [HttpPost("payment")]
        public async Task<ActionResult<TransferResponse>> AddPayment(AddPaymentCommand command)
        {
            return Ok(await addPaymentCommandHandler.Handle(command));
        }

        [HttpPost("withdrawal")]
        public async Task<ActionResult<TransferResponse>> AddWithdrawal(AddWithdrawalCommand command)
        {
            return Ok(await addWithdrawalCommandHandler.Handle(command));
        }
    }
}
