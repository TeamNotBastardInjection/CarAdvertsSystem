using System;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.EditAdverts;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.EditAdvertsPresenterTests
{
    [TestFixture]
    public class View_OnAdvertDeleteItem_Should
    {
        [Test]
        public void ThrowsArumentExeption_WhenIdEventAdvertArgsIdParameterIsNotPositive()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.SetupGet(view => view.Model).Returns(new EditAdvertsViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);

            var idEventAdvertArgs = new IdEventAdvertArgs(0);

            Assert.That(
                 () => editAdvertPresenter.View_OnAdvertDeleteItem(null, idEventAdvertArgs),
                 Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void InvokeIAdvertService_DeleteAdvertByIdMethodOnce()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.SetupGet(view => view.Model).Returns(new EditAdvertsViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);

            var idEventAdvertArgs = new IdEventAdvertArgs(5);

            editAdvertPresenter.View_OnAdvertDeleteItem(null, idEventAdvertArgs);

            advertServiceMock.Verify(a => a.DeleteAdvertById(It.IsAny<int>()), Times.Once);
        }
    }
}
