using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Services
{
    public class VineyardService : IVineyardService
    {
        public readonly IVineyardReposiroty _vineyardReposiroty;

        public VineyardService(IVineyardReposiroty vineyardReposiroty)
        {
            _vineyardReposiroty = vineyardReposiroty;
        }

        public async Task<Dictionary<string, List<string>>> GetVineyardManagersDiccionaryAsync()
        {
            var parcels = await _vineyardReposiroty.GetVineyardManagersAsync();

            var groupedData = parcels
                .GroupBy(parcel => parcel.Vineyard.Name)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .Select(parcel => parcel.Manager.Name)
                        .Distinct()
                        .OrderBy(name => name)
                        .ToList()
                );

            return groupedData;
        }

    }
}
