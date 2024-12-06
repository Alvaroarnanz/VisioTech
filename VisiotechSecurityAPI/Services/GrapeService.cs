using Microsoft.EntityFrameworkCore;
using System.Data;
using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Services
{
    public class GrapeService : IGrapeService
    { 
        public readonly IGrapeRepository _grapeRepository;

        public GrapeService(IGrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        public async Task<Dictionary<string, int>> GetAreaByGrapeAsync()
        {
            var grapes = await _grapeRepository.GetGrapeParcelAsync();

            var areaByGrape = grapes.ToDictionary(
                grape => grape.Name, 
                grape => grape.Parcels.Sum(parcel => parcel.Area) 
            );

            return areaByGrape;
        }
    }
}
