using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Globalization;
using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Domain.Interfaces;
using VisiotechSecurityAPI.Infra;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VisiotechSecurityAPI.Services
{
    public class ManagerService : IManagerService
    {
        public readonly IManagerRepository _managersRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managersRepository = managerRepository;
        }

        public async Task<IEnumerable<int>> GetManagerIdsAsync()
        {
            var result = await _managersRepository.GetManagersAsync();

            return result.Select(x => x.Id).ToList();
        }

        public async Task<Dictionary<string, int>> GetManagerTotalAreaAsync()
        {
            var managers = await _managersRepository.GetManagerParcelAsync();

            var managerTotalArea = managers.ToDictionary(
                                            manager => manager.Name,
                                            manager => manager.Parcels.Sum(x => x.Area));
            return managerTotalArea;
        }

        public async Task<IEnumerable<string>> GetTaxNumbersAsync(bool sorted)
        {
            var result = await _managersRepository.GetManagersAsync();

            if (sorted)
                result = result.OrderBy(x => x.Name);

            return result.Select(x => x.TaxNumber).ToList();

        }
    }
}
