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
    public class CountShould
    {
        [Test]
        public void Count_Should_BeCalled_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAdd = new Mock<Advert>();
            advertService.AddAdvert(advertToAdd.Object);
            advertService.Count();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void Count_Should_NeverBeCalled_IfNotCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAdd = new Mock<Advert>();
            advertService.AddAdvert(advertToAdd.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void Count_Should_ReturnZero_IfThereAreNoAdverts()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedResult = new List<Advert>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedResult.AsQueryable());

            Assert.AreEqual(0, advertService.Count());
        }

        [Test]
        public void Count_Should_ReturnExactNumberOfAdverts_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Advert> expectedResult = new List<Advert>() {new Advert(), new Advert()};
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedResult.AsQueryable());

            Assert.AreEqual(2, advertService.Count());

        }
    }
}
