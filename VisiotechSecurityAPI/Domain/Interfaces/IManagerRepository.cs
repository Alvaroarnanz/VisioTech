using VisiotechSecurityAPI.Domain.Entity;

namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagersAsync();
        Task<IEnumerable<Manager>> GetManagerParcelAsync();

    }
}
