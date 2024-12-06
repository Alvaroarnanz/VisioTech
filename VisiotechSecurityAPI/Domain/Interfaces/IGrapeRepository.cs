using VisiotechSecurityAPI.Domain.Entity;

namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IGrapeRepository
    {
        Task<IEnumerable<Grape>> GetGrapeParcelAsync();
    }
}
