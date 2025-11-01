using Marketplace.Domain.Entities;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class ImagesRepository(MarketplaceDbContext context) : IImagesRepository
    {
        public async Task<Image?> GetById(int id)
        {
            return await context.Image.Where(x => x.Id == id).Include(x => x.Item).FirstOrDefaultAsync();
        }

        public async Task<List<Image>> GetByItem(Item item)
        {
            return await context.Image.Where(x => x.Item == item).ToListAsync();
        }

        public async Task<Image?> GetFrontImageForItemAsync(Item item)
        {
            return await context.Image.Where(x => x.Item == item && x.IsFront == true).FirstOrDefaultAsync();
        }

        public Image? GetFrontImageForItem(Item item)
        {
            return context.Image.Where(x => x.Item == item && x.IsFront == true).FirstOrDefault();
        }

        public async Task<Image?> Add(Image image)
        {
            context.Image.Add(image);
            await context.SaveChangesAsync();
            return image;
        }

        public async Task<Image?> Update(Image image)
        {
            context.Image.Update(image);
            await context.SaveChangesAsync();
            return image;
        }

        public async Task Delete(Image image)
        {
            context.Image.Remove(image);
            await context.SaveChangesAsync();
            return;
        }
    }
}
