using Microsoft.AspNetCore.Http;

namespace Marketplace.Application.Images.Commands
{
    public class AddImageCommand
    {
        public int ItemId { get; set; }
        public required string ImageName { get; set; }
        public required Stream Image {  get; set; }
    }
}
