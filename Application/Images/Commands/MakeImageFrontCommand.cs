using Marketplace.Domain.Interface;

namespace Marketplace.Application.Images.Commands
{
    public class MakeImageFrontCommand
    {
        public int Id { get; set; }

        public MakeImageFrontCommand(int id)
        {
            Id = id;
        }
    }
}
