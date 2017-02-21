using System;
using System.Collections.Generic;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertDetail;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertDetailPresentersTests
{
    [TestFixture]
    public class View_OnGetAdvertsById_Should
    {
        [TestCase(0)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentException_WhenGetPicturePathEventArgsAdvertIdPropertyIsNotPositive(int invalidAdvertId)
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getAdvertsByIdEventArgs = new GetAdvertsByIdEventArgs(invalidAdvertId);

            Assert.That(
                () => advertDetailPresenter.View_OnGetAdvertsById(null, getAdvertsByIdEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void InvokeIAdvertService_GetByIdMethodOnce()
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            advertDetailViewMock.SetupGet(view => view.Model).Returns(new AdvertDetailViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getAdvertsByIdEventArgs = new GetAdvertsByIdEventArgs(3);

            advertDetailPresenter.View_OnGetAdvertsById(null, getAdvertsByIdEventArgs);

            advertServiceMock.Verify(service => service.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestCase("1.jpg")]
        [TestCase("100.jpg")]
        public void AddAdvertsToViewModel_WhenOnGetAdvertsByIdEventIsRaised(string testPicturePath)
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            advertDetailViewMock.SetupGet(view => view.Model).Returns(new AdvertDetailViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            var advert = new Advert() { Title = "Test Advert" };
            advertServiceMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(advert);

            var pictureServiceMock = new Mock<IPictureServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getAdvertsByIdEventArgs = new GetAdvertsByIdEventArgs(3);

            var expectedAdvertsCollection = new List<Advert>();
            expectedAdvertsCollection.Add(advert);
            
            advertDetailViewMock.Raise(v => v.OnGetAdvertsById += null, getAdvertsByIdEventArgs);
            
            CollectionAssert.AreEquivalent(expectedAdvertsCollection, advertDetailViewMock.Object.Model.Adverts);
        }
    }
}
