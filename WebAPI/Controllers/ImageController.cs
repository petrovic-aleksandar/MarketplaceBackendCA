using Marketplace.Application.Images.Commands;
using Marketplace.Application.Images.Queries;
using Marketplace.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(
        GetImagesByItemQueryHandler getImagesByItemQueryHandler,
        AddImageCommandHandler addImageCommandHandler,
        DeleteImageCommandHandler deleteImageCommandHandler,
        MakeImageFrontCommandHandler makeImageFrontCommandHandler
        ) : ControllerBase
    {
        [HttpGet("{itemId}")]
        public async Task<ActionResult<List<ImageResponse>>> GetByItemId(int itemId)
        {
            return Ok(await getImagesByItemQueryHandler.Handle(new GetImagesByItemQuery((itemId))));
        }

        [HttpPost("{itemId}"), DisableRequestSizeLimit]
        public async Task<ActionResult<ImageResponse>> Upload(int itemId, AddImageCommand command)
        {
            return Ok(await addImageCommandHandler.Handle(command));
        }

        [HttpPost("front/{id}")]
        public async Task<ActionResult<ImageResponse>> MakeImageFront(int id)
        {
            return Ok(await makeImageFrontCommandHandler.Handle(new MakeImageFrontCommand(id)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await deleteImageCommandHandler.Handle(new DeleteImageCommand(id));
            return Ok();
        }
    }
}
