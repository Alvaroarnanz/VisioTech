using Microsoft.AspNetCore.Mvc;

namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IGrapeService
    {
        Task<Dictionary<string, int>> GetAreaByGrapeAsync();
    }
}
