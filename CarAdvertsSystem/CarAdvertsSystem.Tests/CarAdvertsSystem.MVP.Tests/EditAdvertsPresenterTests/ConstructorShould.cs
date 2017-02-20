using System;

using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.EditAdverts;

using NUnit.Framework;
using Moq;
using WebFormsMvp;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.EditAdvertsPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceException_WhenIEditAdvertsViewIsNull()
        {
            IEditAdvertsView editAdvertsView = null;
            var advertService = new Mock<IAdvertServices>();

            Assert.That(
                () => new EditAdvertsPresenter(editAdvertsView, advertService.Object),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenIAdvertServiceIsNull()
        {
            var editAdvertsView = new Mock<IEditAdvertsView>();
            IAdvertServices advertService = null;

            Assert.That(() => new EditAdvertsPresenter(editAdvertsView.Object, advertService), 
                Throws.ArgumentNullException.With.Message.Contains("Advert Service Instance is Null!!"));
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var editAdvertsView = new Mock<IEditAdvertsView>();
            var advertService = new Mock<IAdvertServices>();

            var editAdvertsPresenter = new EditAdvertsPresenter(editAdvertsView.Object, advertService.Object);

            Assert.That(editAdvertsPresenter, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var editAdvertsView = new Mock<IEditAdvertsView>();
            var advertService = new Mock<IAdvertServices>();

            var editAdvertsPresenter = new EditAdvertsPresenter(editAdvertsView.Object, advertService.Object);

            Assert.That(editAdvertsPresenter, Is.InstanceOf<Presenter<IEditAdvertsView>>());

        }
    }
}
