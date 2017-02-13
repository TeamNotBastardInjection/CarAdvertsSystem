using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class DeleteAdvertShould
    {
        [Test]
        public void DeleteAdvert_Should_BeCalled_IfAdvertIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertToAddAndDelete = new Mock<Advert>();
            advertService.AddAdvert(advertToAddAndDelete.Object);
            advertService.DeleteAdvert(advertToAddAndDelete.Object);

            mockedRepository.Verify(rep => rep.Delete(advertToAddAndDelete.Object));
        }

        [Test]
        public void DeleteAdvert_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<Advert> advertAsNull = null;

            Assert.Throws<NullReferenceException>(() => advertService.DeleteAdvert(advertAsNull.Object));
        }

        [Test]
        public void DeleteAdvert_Should_NotDeleteAdvertThatIsNeverAddedInTheFirstPlace()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertThatIsNotAdded = new Mock<Advert>();

            mockedRepository.Verify(rep => rep.Delete(advertThatIsNotAdded.Object), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_CallSaveChangesTwoTimes_IfAdvertIsValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advert = new Mock<Advert>();
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            mockedUnitOfWork.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void DeleteAdvert_Should_NotCallSaveChanges_IfAdvertIsNotDelete()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advertThatIsNotAdded = new Mock<Advert>();

            mockedUnitOfWork.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var advert = new Mock<Advert>();
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            mockedRepository.Verify(rep => rep.Delete(It.IsAny<Advert>()), Times.Once);
        }
    }
}
