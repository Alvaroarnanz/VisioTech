using Microsoft.EntityFrameworkCore;
using VisiotechSecurityAPI.Domain.Data;
using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Infra
{
    public class VineyardRepository : IVineyardReposiroty
    {
        public readonly AppDbContext _context;

        public VineyardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parcel>> GetVineyardManagersAsync()
        {
            var result = await _context.Parcels
                         .Include(x => x.Vineyard)
                         .Include(x => x.Manager)                      
                         .ToListAsync();
            return result;
        }
    }
}
