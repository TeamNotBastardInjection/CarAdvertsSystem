using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.VehicleModelTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            var vehicleModel = new Mock<VehicleModel>();
            vehicleModelService.GetById(vehicleModel.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(vehicleModel.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperVehicleModelWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            var vehicleModelWithId = new Mock<VehicleModel>();
            mockedRepository.Setup(rep => rep.GetById(vehicleModelWithId.Object.Id)).Returns(() => vehicleModelWithId.Object);

            Assert.IsInstanceOf<VehicleModel>(vehicleModelService.GetById(vehicleModelWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            var vehicleModelWithId = new Mock<VehicleModel>();
            mockedRepository.Setup(rep => rep.GetById(vehicleModelWithId.Object.Id)).Returns(() => vehicleModelWithId.Object);

            Assert.AreEqual(vehicleModelService.GetById(vehicleModelWithId.Object.Id), vehicleModelWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfVehicleModelIsNull()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            Mock<VehicleModel> vehicleModelWithId = null;

            Assert.Throws<NullReferenceException>(() => vehicleModelService.GetById(vehicleModelWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoVehicleModelYolo()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(vehicleModelService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectVehicleModel_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<VehicleModel>>();
            var vehicleModelService = new VehicleModelServices(mockedRepository.Object);

            var vehicleModel = new Mock<VehicleModel>();
            var secondVehicleModel = new Mock<VehicleModel>();
            mockedRepository.Setup(rep => rep.GetById(vehicleModel.Object.Id)).Returns(() => vehicleModel.Object);

            Assert.AreNotEqual(vehicleModelService.GetById(vehicleModel.Object.Id), secondVehicleModel.Object);
        }
    }
}
