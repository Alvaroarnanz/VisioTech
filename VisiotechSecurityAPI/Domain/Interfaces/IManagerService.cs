namespace VisiotechSecurityAPI.Domain.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<int>> GetManagerIdsAsync();
        Task<Dictionary<string, int>> GetManagerTotalAreaAsync();
        Task<IEnumerable<string>> GetTaxNumbersAsync(bool sorted);
    }
}
