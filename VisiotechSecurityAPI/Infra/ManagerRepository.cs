using Microsoft.EntityFrameworkCore;
using VisiotechSecurityAPI.Domain.Data;
using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Infra
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly AppDbContext _context;

        public ManagerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetManagersAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<IEnumerable<Manager>> GetManagerParcelAsync()
        {
            return await _context.Managers
                        .Include(x => x.Parcels)
                        .ToListAsync();
        }
    }
}   
