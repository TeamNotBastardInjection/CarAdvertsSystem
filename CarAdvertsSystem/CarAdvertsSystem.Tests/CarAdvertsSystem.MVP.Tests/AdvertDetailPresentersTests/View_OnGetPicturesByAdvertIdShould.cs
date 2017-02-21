using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertDetail;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertDetailPresentersTests
{
    [TestFixture]
    public class View_OnGetPicturesByAdvertId_Should
    {
        [TestCase(0)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentException_WhenGetPicturesEventArgsAdvertIdPropertyIsNotPositive(int invalidAdvertId)
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getPicturesEventArgs = new GetPicturesEventArgs(invalidAdvertId);

            Assert.That(
                () => advertDetailPresenter.View_OnGetPicturesByAdvertId(null, getPicturesEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void InvokeIPictureService_GetPicturesByAdvertIdMethodOnce()
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            advertDetailViewMock.SetupGet(view => view.Model).Returns(new AdvertDetailViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getPicturesEventArgs = new GetPicturesEventArgs(3);

            advertDetailPresenter.View_OnGetPicturesByAdvertId(null, getPicturesEventArgs);

            pictureServiceMock.Verify(service => service.GetPicturesByAdvertId(It.IsAny<int>()), Times.Once);
        }

        [TestCase("1.jpg")]
        [TestCase("100.jpg")]
        public void AddPicturesToViewModel_WhenOnGetPicturesByAdvertIdEventIsRaised(string testPicturePath)
        {
            var advertDetailViewMock = new Mock<IAdvertDetailView>();
            advertDetailViewMock.SetupGet(view => view.Model).Returns(new AdvertDetailViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();

            var pictures = new List<Picture>()
            {
                new Picture() {Name = "1.jpg"},
                new Picture() {Name = "2.jpg"},
            }.AsQueryable();
            var pictureServiceMock = new Mock<IPictureServices>();
            pictureServiceMock.Setup(p => p.GetPicturesByAdvertId(It.IsAny<int>())).Returns(pictures);

            var advertDetailPresenter = new AdvertDetailPresenter(
                advertDetailViewMock.Object,
                pictureServiceMock.Object,
                advertServiceMock.Object);

            var getPicturesEventArgs = new GetPicturesEventArgs(3);
            
            advertDetailViewMock.Raise(v => v.OnGetPicturesByAdvertId += null, getPicturesEventArgs);

            CollectionAssert.AreEquivalent(pictures, advertDetailViewMock.Object.Model.Pictures);
        }
    }
}
