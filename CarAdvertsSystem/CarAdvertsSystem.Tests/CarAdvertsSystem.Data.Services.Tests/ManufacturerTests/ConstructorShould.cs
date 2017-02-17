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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.That(manufacturerService, Is.InstanceOf<ManufacturerServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<Manufacturer>> mockedRepository = null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<NullReferenceException>(
                () => new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void Constuctor_Should_ThrowNullReferenceException_IfPassedUnitOfWorkIsNull()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            Mock<IUnitOfWork> mockedUnitOfWork = null;

            Assert.Throws<NullReferenceException>(
                () => new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }
    }
}
