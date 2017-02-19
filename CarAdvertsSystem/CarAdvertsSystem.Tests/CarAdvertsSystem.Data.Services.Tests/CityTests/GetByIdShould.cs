using System;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CityTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            var city = new Mock<City>();
            cityService.GetById(city.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(city.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<City>>();

            var cityService = new CityServices(mockedRepository.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperCityWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            var cityWithId = new Mock<City>();
            mockedRepository.Setup(rep => rep.GetById(cityWithId.Object.Id)).Returns(() => cityWithId.Object);

            Assert.IsInstanceOf<City>(cityService.GetById(cityWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            var cityWithId = new Mock<City>();
            mockedRepository.Setup(rep => rep.GetById(cityWithId.Object.Id)).Returns(() => cityWithId.Object);

            Assert.AreEqual(cityService.GetById(cityWithId.Object.Id), cityWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfCityIsNull()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            Mock<City> cityWithIdNull = null;

            Assert.Throws<NullReferenceException>(() => cityService.GetById(cityWithIdNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnCity_IfThereIsNoCityYolo()
        {
            var mockedRepository = new Mock<IRepository<City>>();
            var cityService = new CityServices(mockedRepository.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(cityService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectCity_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<City>>();

            var cityService = new CityServices(mockedRepository.Object);

            var city = new Mock<City>();
            var secondCity = new Mock<City>();
            mockedRepository.Setup(rep => rep.GetById(city.Object.Id)).Returns(() => city.Object);

            Assert.AreNotEqual(cityService.GetById(city.Object.Id), secondCity.Object);
        }
    }
}
