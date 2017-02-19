using System;
using NUnit.Framework;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CityTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateCityServices_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<City>>();

            var cityService = new CityServices(mockedRepository.Object);

            Assert.That(cityService, Is.InstanceOf<CityServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<City>> mockedRepository = null;

            Assert.Throws<NullReferenceException>(
                () => new CityServices(mockedRepository.Object));
        }
    }
}
