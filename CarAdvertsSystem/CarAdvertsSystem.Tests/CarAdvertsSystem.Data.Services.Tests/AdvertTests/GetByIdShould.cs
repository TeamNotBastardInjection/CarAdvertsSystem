using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advert = new Mock<Advert>();
            advertService.GetById(advert.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(advert.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperAdvertWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertWithId = new Mock<Advert>();
            mockedRepository.Setup(rep => rep.GetById(advertWithId.Object.Id)).Returns(() => advertWithId.Object);

            Assert.IsInstanceOf<Advert>(advertService.GetById(advertWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertWithId = new Mock<Advert>();
            mockedRepository.Setup(rep => rep.GetById(advertWithId.Object.Id)).Returns(() => advertWithId.Object);

            Assert.AreEqual(advertService.GetById(advertWithId.Object.Id), advertWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<Advert> advertThatIsNull = null;

            Assert.Throws<NullReferenceException>(() => advertService.GetById(advertThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoAdvertYolo()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(advertService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectAdvert_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advert = new Mock<Advert>();
            var secondAdvert = new Mock<Advert>();
            mockedRepository.Setup(rep => rep.GetById(advert.Object.Id)).Returns(() => advert.Object);

            Assert.AreNotEqual(advertService.GetById(advert.Object.Id), secondAdvert.Object);
        }
    }
}
