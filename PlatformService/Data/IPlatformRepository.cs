namespace PlatformService.Data
{
    using PlatformService.Models;

    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}