using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interface
{
    public interface IImagesRepository
    {
        Task<Image?> GetById(int id);
        Task<List<Image>> GetByItem(Item item);
        Task<Image?> GetFrontImageForItem(Item item);
        Task<Image?> Add(Image image);
        Task<Image?> Update(Image image);
        Task Delete(Image image);

    }
}
