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
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            Assert.That(vehicleModelService, Is.InstanceOf<VehicleModelServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<VehicleModel>> mockedRepository = null;

            Assert.Throws<NullReferenceException>(
                () => new VehicleModelServices(mockedRepository.Object));
        }
    }
}
