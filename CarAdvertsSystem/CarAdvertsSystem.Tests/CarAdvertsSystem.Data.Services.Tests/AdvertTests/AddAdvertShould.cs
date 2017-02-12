using System;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class AddAdvertShould
    {
        [Test]
        public void AddAdvert_Should_BeCalled_IfAdvertIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAdd = new Mock<Advert>();
            advertService.AddAdvert(advertToAdd.Object);

            mockedRepository.Verify(rep => rep.Add(advertToAdd.Object));
        }

        [Test]
        public void AddAdvert_Should_BeCalledOnce_IfAdvertIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAdd = new Mock<Advert>();
            advertService.AddAdvert(advertToAdd.Object);

            mockedRepository.Verify(rep => rep.Add(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void AddAdvert_Should_CallSaveChanges_IfAdvertIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAdd = new Mock<Advert>();
            advertService.AddAdvert(advertToAdd.Object);

            mockedUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddAdvert_ShouldThrowNullReferenceException_IfPassedAdvertIsNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<Advert> advertToAdd = null;

            Assert.Throws<NullReferenceException>(() => advertService.AddAdvert(advertToAdd.Object));
        }
    }
}
