using System;

using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertDetail;

using Moq;
using NUnit.Framework;
using WebFormsMvp;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertDetailPresentersTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceException_WhenIAdvertDetailViewIsNull()
        {
            IAdvertDetailView advertDetailView = null;
            var pictureService = new Mock<IPictureServices>();        
            var advertService = new Mock<IAdvertServices>();

            Assert.That(
                () => new AdvertDetailPresenter(advertDetailView, pictureService.Object, advertService.Object),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenIPictureServiceIsNull()
        {
            var advertDetailView = new Mock<IAdvertDetailView>();
            IPictureServices pictureService = null;
            var advertService = new Mock<IAdvertServices>();

            Assert.That(
                () => new AdvertDetailPresenter(advertDetailView.Object, pictureService, advertService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Picture Service is Null"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenIAdvertServiceIsNull()
        {
            var advertDetailView = new Mock<IAdvertDetailView>();
            var pictureService = new Mock<IPictureServices>();
            IAdvertServices advertService = null;

            Assert.That(
                () => new AdvertDetailPresenter(advertDetailView.Object, pictureService.Object, advertService),
                Throws.ArgumentNullException.With.Message.Contains("Advert Service is Null"));
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var advertDetailView = new Mock<IAdvertDetailView>();
            var pictureService = new Mock<IPictureServices>();
            var advertService = new Mock<IAdvertServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(advertDetailView.Object, pictureService.Object, advertService.Object);

            Assert.That(advertDetailPresenter, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var advertDetailView = new Mock<IAdvertDetailView>();
            var pictureService = new Mock<IPictureServices>();
            var advertService = new Mock<IAdvertServices>();

            var advertDetailPresenter = new AdvertDetailPresenter(advertDetailView.Object, pictureService.Object, advertService.Object);

            Assert.That(advertDetailPresenter, Is.InstanceOf<Presenter<IAdvertDetailView>>());
        }
    }
}
