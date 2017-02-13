using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class DeleteAdvertByIdShould
    {
        [Test]
        public void DeleteAdvertById_Should_BeCalled_IfAdvertToDeleteIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToDeleteWithId = new Mock<Advert>();
            advertService.AddAdvert(advertToDeleteWithId.Object);
            advertService.DeleteAdvertById(advertToDeleteWithId.Object.Id);

            mockedRepository.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id));
        }

        [Test]
        public void DeleteAdvertById_Should_BeCalledOnce_IfAdvertToDeleteIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToDeleteWithId = new Mock<Advert>();
            advertService.AddAdvert(advertToDeleteWithId.Object);
            advertService.DeleteAdvertById(advertToDeleteWithId.Object.Id);

            mockedRepository.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id), Times.Once);

        }

        [Test]
        public void DeleteAdvertById_Should_NotDeleteAdvert_IfItIsNotAddedInTheFirstPlace()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToDeleteWithId = new Mock<Advert>();

            mockedRepository.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id), Times.Never);
        }

        [Test]
        public void DeleteAdvertById_Should_CallSaveChanges_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertWithId = new Mock<Advert>();
            advertService.AddAdvert(advertWithId.Object);
            advertService.DeleteAdvertById(advertWithId.Object.Id);

            mockedUnitOfWork.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void DeleteAdvertById_Should_ThrowNullReferenceException_IfAdvertIsNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<Advert> advertWithId = null;

            Assert.Throws<NullReferenceException>(() => advertService.DeleteAdvertById(advertWithId.Object.Id));
        }
    }
}
