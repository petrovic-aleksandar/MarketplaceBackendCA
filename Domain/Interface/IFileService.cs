namespace Marketplace.Domain.Interface
{
    public interface IFileService
    {
        public void SaveFile(string path, Stream fileStream);
    }
}
