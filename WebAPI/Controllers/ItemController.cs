using Marketplace.Application.Items.Commands;
using Marketplace.Application.Items.Queries;
using Marketplace.Application.ItemTypes.Queries;
using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(
        GetItemByIdQueryHandler getItemByIdQueryHandler,
        GetItemsBySellerQueryHandler getItemsBySellerQueryHandler,
        GetItemsByTypeQueryHandler getItemsByTypeQueryHandler,
        ActivateItemCommandHandler activateItemCommandHandler,
        AddItemCommandHandler addItemCommandHandler,
        ChangeItemOwnerCommandHandler changeItemOwnlerCommandHandler,
        DeactivateItemCommandHandler deactivateItemCommandHandler,
        DeleteItemCommandHandler deleteItemCommandHandler,
        UpdateItemCommandHandler updateItemCommandHandler,
        GetItemTypesQueryHandler getItemTypesQueryHandler
        ) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponse>> GetById(int id)
        {
            return Ok(await getItemByIdQueryHandler.Handle(new GetItemByIdQuery(id)));
        }

        [HttpGet("byTypeId/{typeId}")]
        public async Task<ActionResult<List<ItemResponse>>> GetByType(int typeId)
        {
            return Ok(await getItemsByTypeQueryHandler.Handle(new GetItemsByTypeQuery(typeId)));
        }

        [HttpGet("bySellerId/{sellerId}")]
        public async Task<ActionResult<ItemResponse>> GetItemsByUser(int sellerId)
        {
            return Ok(await getItemsBySellerQueryHandler.Handle(new GetItemsBySellerQuery(sellerId)));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<ActionResult<Item>> Add(AddItemCommand command)
        {
            return Ok(await addItemCommandHandler.Handle(command));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, UpdateItemCommand command)
        {
            return Ok(await updateItemCommandHandler.Handle(command with { Id = id }));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("Deactivate/{id}")]
        public async Task<ActionResult<Item>> Deactivate(int id)
        {
            return Ok(await deactivateItemCommandHandler.Handle(new DeactivateItemCommand(id)));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<Item>> Activate(int id)
        {
            return Ok(await activateItemCommandHandler.Handle(new ActivateItemCommand(id)));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("Delete/{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            return Ok(await deleteItemCommandHandler.Handle(new DeleteItemCommand(id)));
        }

        [HttpGet("Types")]
        public async Task<ActionResult<ItemType>> GetItemTypes()
        {
            return Ok(await getItemTypesQueryHandler.Handle(new GetItemTypesQuery()));
        }
    }
}
