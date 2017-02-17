using System;
using System.Collections.Generic;
using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class GetAllAdvertsShould
    {
        [Test]
        public void GetAllAdverts_Should_BeCalled_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            advertService.GetAllAdverts();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllAdverts_Should_NotBeCalled_IfItIsNeverCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnIQueryable_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() {new Advert(), new Advert()};
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            Assert.IsInstanceOf<IQueryable<Advert>>(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_DoItsJobCorrectly_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() { new Advert(), new Advert() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            Assert.AreEqual(advertService.GetAllAdverts(), expectedAdvertsResult);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnEmptyCollection_IfThereAreNoAdvertsAdded()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            Assert.IsEmpty(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedAdvertsResult = null;
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            Assert.Throws<ArgumentNullException>(() => advertService.GetAllAdverts());
        }
    }
}
