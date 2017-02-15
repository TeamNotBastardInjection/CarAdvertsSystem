using System;
using System.Collections.Generic;
using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.VehicleModelTests
{
    [TestFixture]
    public class GetAllVehicleModelsShould
    {
        [Test]
        public void GetAllVehicleModels_Should_BeCalled_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            vechicleModelService.GetAllVehicleModels();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllVehicleModels_Should_NotBeCalled_IfItIsNeverCalled()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllVehicleModels_Should_ReturnIQueryable_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<VehicleModel> expectedVehicleModelResult = new List<VehicleModel>() { new VehicleModel(), new VehicleModel() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedVehicleModelResult.AsQueryable());

            Assert.IsInstanceOf<IQueryable<VehicleModel>>(vechicleModelService.GetAllVehicleModels());
        }

        [Test]
        public void GetAllVehicleModels_Should_DoItsJobCorrectly_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<VehicleModel> expectedVehicleModelResult = new List<VehicleModel>() { new VehicleModel(), new VehicleModel() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedVehicleModelResult.AsQueryable());

            Assert.AreEqual(vechicleModelService.GetAllVehicleModels(), expectedVehicleModelResult);
        }

        [Test]
        public void GetAllVehicleModels_Should_ReturnEmptyCollection_IfThereAreNoVehicleModelsAdded()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<VehicleModel> expectedVehicleModelResult = new List<VehicleModel>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedVehicleModelResult.AsQueryable());

            Assert.IsEmpty(vechicleModelService.GetAllVehicleModels());
        }

        [Test]
        public void GetAllVehicleModels_Should_ThrowArgumentNullException_IfPassedVehicleModelsAreNull()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var vechicleModelService = new VehicleModelServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<VehicleModel> expectedVehicleModelResult = null;
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedVehicleModelResult.AsQueryable());

            Assert.Throws<ArgumentNullException>(() => vechicleModelService.GetAllVehicleModels());
        }
    }
}
