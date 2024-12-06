namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IVineyardService
    {
        Task<Dictionary<string, List<string>>> GetVineyardManagersDiccionaryAsync();
    }
}
