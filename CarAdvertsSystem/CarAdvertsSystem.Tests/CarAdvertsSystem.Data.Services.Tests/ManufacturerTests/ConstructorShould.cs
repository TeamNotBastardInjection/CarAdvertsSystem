using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.ManufacturerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateManufacturerServices_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();

            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            Assert.That(manufacturerService, Is.InstanceOf<ManufacturerServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<Manufacturer>> mockedRepository = null;


            Assert.Throws<NullReferenceException>(
                () => new ManufacturerServices(mockedRepository.Object));
        }
    }
}
