using VisiotechSecurityAPI.Domain.Entity;
using VisiotechSecurityAPI.Services;
using Moq;
using VisiotechSecurityAPI.Domain.Interfaces;


namespace VisioTechSecurity.Test
{
    public class VineyardServiceUnitTest
    {
        [Fact]
        public async Task GetVineyardManagersDiccionaryAsync_ReturnsCorrectDictionary()
        {
            // Arrange
            var mockVineyardRepositry = new Mock<IVineyardReposiroty>();

            // Datos fake
            var parcels = new List<Parcel>
        {
            new Parcel
            {
                Vineyard = new Vineyard { Name = "bogeda1" },
                Manager = new Manager { Name = "Zacarias"}

            },
            new Parcel
            {
                Vineyard = new Vineyard { Name = "bogeda2" },
                Manager = new Manager { Name = "Zacarias"}

            },
             new Parcel
            {
                Vineyard = new Vineyard { Name = "bogeda1" },
                Manager = new Manager { Name = "Alvaro"}

            },
             new Parcel
            {
                Vineyard = new Vineyard { Name = "bogeda2" },
                Manager = new Manager { Name = "Carmen"}

            },new Parcel
            {
                Vineyard = new Vineyard { Name = "bogeda2" },
                Manager = new Manager { Name = "Maria"}

            },
        };

            // Mockamos los datos del metodo GetGrapeParcelAsync()
            mockVineyardRepositry
                .Setup(repo => repo.GetVineyardManagersAsync())
                .ReturnsAsync(parcels);

            // Crear la instancia de GrapeService con el Mock como parametro del constructor
            var service = new VineyardService(mockVineyardRepositry.Object);

            // Act
            var result = await service.GetVineyardManagersDiccionaryAsync();
            var reddtulr = new List<string> {"Alvaro", "Zacarias"};
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count); // Tiene que tener dos bodegas
            Assert.Equal(["Alvaro","Zacarias"], result["bogeda1"]); // Los nombres tienen que ser "Alvaro" y "Zacarias", en ese orden
            Assert.Equal(["Carmen","Maria","Zacarias"], result["bogeda2"]);// Los nombres tienen que ser "Carmen", "Maria" y "Zacarias" en ese orden
        }
    }
}
