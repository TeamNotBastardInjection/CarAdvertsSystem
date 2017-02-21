using System;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.EditAdverts;
using NUnit.Framework;
using Moq;
using System.Web.ModelBinding;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.EditAdvertsPresenterTests
{
    [TestFixture]
    public class View_OnAdvertUpdateItem_Should
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
                 () => editAdvertPresenter.View_OnAdvertUpdateItem(null, idEventAdvertArgs),
                 Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void InvokeIAdvertService_GetByIdMethodColledOnce()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var advert = new Advert() { Title = "Test Advert" };
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(advert);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(5);

            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);

            advertServiceMock.Verify(a => a.GetById(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            string errorKey = string.Empty;
            int advertId = 1;
            string expectedError = $"Item with id {advertId} was not found";
            
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns<Advert>(null);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(advertId);
            
            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);
            
            Assert.AreEqual(1, editAdvertViewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, editAdvertViewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }
        

        [Test]
        public void TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns<Advert>(null);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(5);
            
            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);
            
            editAdvertViewMock.Verify(v => v.TryUpdateModel(It.IsAny<Advert>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var advert = new Advert() {Title = "Test Advert"};
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(advert);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(5);

            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);

            editAdvertViewMock.Verify(v => v.TryUpdateModel(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void UpdateAdvertIsCalld_WhenItemIsFoundAndIsInValidState()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var advert = new Advert() { Title = "Test Advert" };
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(advert);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(5);

            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);

            advertServiceMock.Verify(a => a.UpdateAdvert(It.IsAny<Advert>()), Times.Once());
        }

        [Test]
        public void UpdateAdvertIsNotCalld_WhenItemIsNotFoundAndIsInValidState()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(c => c.GetById(It.IsAny<int>())).Returns<Advert>(null);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);
            var idEventAdvertArgs = new IdEventAdvertArgs(5);

            editAdvertViewMock.Raise(v => v.OnAdvertUpdateItem += null, idEventAdvertArgs);

            advertServiceMock.Verify(a => a.UpdateAdvert(It.IsAny<Advert>()), Times.Never);
        }
    }
}
