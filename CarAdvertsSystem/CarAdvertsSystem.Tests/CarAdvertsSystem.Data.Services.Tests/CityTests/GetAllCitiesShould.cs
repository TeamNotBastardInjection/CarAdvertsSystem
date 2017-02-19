using System;
using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CityTests
{
    [TestFixture]
    public class GetAllCitiesShould
    {
        [Test]
        public void GetAllCities_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            cityService.GetAllCities();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllCities_Should_NotBeCalled_IfItIsNeverCalled()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllCities_Should_ReturnIQueryable_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<City>>();

            var cityService = new CityServices(mockedRepository.Object);

            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            Assert.IsInstanceOf<IQueryable<City>>(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_DoItsJobCorrectly_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<City>>();

            var cityService = new CityServices(mockedRepository.Object);

            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            Assert.AreEqual(cityService.GetAllCities(), expectedCitiesResult);
        }

        [Test]
        public void GetAllCities_Should_ReturnEmptyCollection_IfThereAreNoCitiesAdded()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            IEnumerable<City> expectedCitiesResult = new List<City>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            Assert.IsEmpty(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            IEnumerable<City> expectedCitiesResult = null;
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            Assert.Throws<ArgumentNullException>(() => cityService.GetAllCities());
        }
    }
}
