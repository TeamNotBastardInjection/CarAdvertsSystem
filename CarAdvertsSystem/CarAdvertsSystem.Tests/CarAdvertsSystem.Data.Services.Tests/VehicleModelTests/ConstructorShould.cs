using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.VehicleModelTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateVehicleModelServices_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.That(vehicleModelService, Is.InstanceOf<VehicleModelServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<VehicleModel>> mockedRepository = null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<NullReferenceException>(
                () => new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void Constuctor_Should_ThrowNullReferenceException_IfPassedUnitOfWorkIsNull()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            Mock<IUnitOfWork> mockedUnitOfWork = null;

            Assert.Throws<NullReferenceException>(
                () => new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }
    }
}
