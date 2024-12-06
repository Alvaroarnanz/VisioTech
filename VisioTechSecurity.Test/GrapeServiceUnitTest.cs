using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Services;
using Moq;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisioTechSecurity.Test
{
    public class GrapeServiceUnitTest
    {
        [Fact]
        public async Task GetAreaByGrapeAsync_ReturnsCorrectDictionary()
        {
            // Arrange
            var mockGrapeRepositry = new Mock<IGrapeRepository>();

            // Datos fake 
            var grapes = new List<Grape>
        {
            new Grape
            {
                Name = "uva1",
                Parcels = new List<Parcel>
                {
                    new Parcel { Area = 100 },
                    new Parcel { Area = 200 }
                }
            },
            new Grape
            {
                Name = "uva2",
                Parcels = new List<Parcel>
                {
                    new Parcel { Area = 150 },
                    new Parcel { Area = 50 }
                }
            }
        };

            // Mockamos los datos del metodo GetGrapeParcelAsync()
            mockGrapeRepositry
                .Setup(repo => repo.GetGrapeParcelAsync())
                .ReturnsAsync(grapes);

            // Crear la instancia de GrapeService con el mockGrapeRepositry como parametro del constructor
            var service = new GrapeService(mockGrapeRepositry.Object);

            // Act
            var result = await service.GetAreaByGrapeAsync();

            // Assert
            Assert.NotNull(result); // El resultado no tiene que ser null
            Assert.Equal(2, result.Count); // Tiene que tener dos tipos de uvas
            Assert.Equal(300, result["uva1"]); // Suma de areas de la uva1
            Assert.Equal(200, result["uva2"]); // Suma de areas de la uva2
        }
    }
}
