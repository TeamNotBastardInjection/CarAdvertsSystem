using System;
using System.Collections.Generic;
using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.ManufacturerTests
{
    [TestFixture]
    public class GetAllManufacturersShould
    {
        [Test]
        public void GetAllManufacturersShould_BeCalled_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            manufacturerService.GetAllManufacturers();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllManufacturers_Should_NotBeCalled_IfItIsNeverCalled()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllManufacturers_Should_ReturnIQueryable_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Manufacturer> expectedManufacturerResult = new List<Manufacturer>() { new Manufacturer(), new Manufacturer() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedManufacturerResult.AsQueryable());

            Assert.IsInstanceOf<IQueryable<Manufacturer>>(manufacturerService.GetAllManufacturers());
        }

        [Test]
        public void GetAllManufacturers_Should_DoItsJobCorrectly_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Manufacturer> expectedManufacturerResult = new List<Manufacturer>() { new Manufacturer(), new Manufacturer() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedManufacturerResult.AsQueryable());

            Assert.AreEqual(manufacturerService.GetAllManufacturers(), expectedManufacturerResult);
        }

        [Test]
        public void GetAllManufacturers_Should_ReturnEmptyCollection_IfThereAreNoManufacturersAdded()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Manufacturer> expectedManufacturerResult = new List<Manufacturer>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedManufacturerResult.AsQueryable());

            Assert.IsEmpty(manufacturerService.GetAllManufacturers());
        }

        [Test]
        public void GetAllManufacturers_Should_ThrowArgumentNullException_IfPassedManufacturersAreNull()
        {
            var mockedRepository = new Mock<IRepository<Manufacturer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var manufacturerService = new ManufacturerServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Manufacturer> expectedManufacturerResult = null;
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedManufacturerResult.AsQueryable());

            Assert.Throws<ArgumentNullException>(() => manufacturerService.GetAllManufacturers());
        }
    }
}
