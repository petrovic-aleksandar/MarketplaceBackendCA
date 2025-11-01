using Marketplace.Domain.Interface;

namespace Marketplace.Infrastructure.Service
{
    public class FileService : IFileService
    {
        public void SaveFile(string fullPath, Stream fileStream)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using var stream = new FileStream(fullPath, FileMode.Create);
                fileStream.CopyTo(stream);
            }
            catch (Exception)
            {
                throw new Exception("Error while saving the image");
            }
        }
    }
}
