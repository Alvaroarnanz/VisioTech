using VisiotechSecurityAPI.Domain.Entity;

namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IVineyardReposiroty
    {
        Task<List<Parcel>> GetVineyardManagersAsync();
    }
}
