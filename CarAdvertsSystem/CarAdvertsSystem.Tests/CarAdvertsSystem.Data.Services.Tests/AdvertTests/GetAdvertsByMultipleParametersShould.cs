using NUnit.Framework;
using Moq;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Services;

using System.Linq;
using System.Collections.Generic;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class GetAdvertsByMultipleParametersShould
    {
        [Test]
        public void ReturnCorrectAdverts_WhenCorrectParameters()
        {
            int vehicleModelId = 1;
            int cityId = 1;
            int minPrice = 1;
            int maxPrice = 4;
            int yearFrom = 1958;
            int yearTo = 3000;

            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advert = new Mock<Advert>();
            var secondAdvert = new Mock<Advert>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => new List<Advert>() {
                new Advert { Id = 1, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 2, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 3, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 4, VehicleModelId = 2, CityId = 1, Price = 2, Year = 2000 }
            }.AsQueryable());

            // Act
            var result = advertService.GetAdvertsByMultipleParameters(vehicleModelId, cityId, minPrice, maxPrice, yearFrom, yearTo).ToList();

            Assert.AreEqual(3, result.Count);
        }

        
    }
}
