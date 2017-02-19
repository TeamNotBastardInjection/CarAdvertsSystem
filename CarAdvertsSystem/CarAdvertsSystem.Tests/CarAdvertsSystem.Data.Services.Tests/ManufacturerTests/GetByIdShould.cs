using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.ManufacturerTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            var manufacturer = new Mock<Manufacturer>();
            manufacturerService.GetById(manufacturer.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(manufacturer.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperManufacturerWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            var manufacturerWithId = new Mock<Manufacturer>();
            mockedRepository.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            Assert.IsInstanceOf<Manufacturer>(manufacturerService.GetById(manufacturerWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            var manufacturerWithId = new Mock<Manufacturer>();
            mockedRepository.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            Assert.AreEqual(manufacturerService.GetById(manufacturerWithId.Object.Id), manufacturerWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfManufacturerIsNull()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            Mock<Manufacturer> manufacturerWithId = null;

            Assert.Throws<NullReferenceException>(() => manufacturerService.GetById(manufacturerWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoManufacturerYolo()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(manufacturerService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectManufacturer_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object);

            var manufacturer = new Mock<Manufacturer>();
            var secondManufacturer = new Mock<Manufacturer>();
            mockedRepository.Setup(rep => rep.GetById(manufacturer.Object.Id)).Returns(() => manufacturer.Object);

            Assert.AreNotEqual(manufacturerService.GetById(manufacturer.Object.Id), secondManufacturer.Object);
        }
    }
}
