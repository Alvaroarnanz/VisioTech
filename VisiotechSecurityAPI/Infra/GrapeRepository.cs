using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using VisiotechSecurityAPI.Domain.Data;
using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Infra
{
    public class GrapeRepository : IGrapeRepository
    {
        private readonly AppDbContext _context;

        public GrapeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grape>> GetGrapeParcelAsync()
        {
            return await _context.Grapes
             .Include(x => x.Parcels)
             .ToListAsync();
        }
    }
}
