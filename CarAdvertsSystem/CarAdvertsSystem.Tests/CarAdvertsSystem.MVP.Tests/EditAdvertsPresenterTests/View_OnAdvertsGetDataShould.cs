using System;
using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.EditAdverts;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.EditAdvertsPresenterTests
{
    [TestFixture]
    public class View_OnAdvertsGetData_Should
    {
        [Test]
        public void InvokeIAdvertService_GetAllAdvertsMethodOnce()
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.SetupGet(view => view.Model).Returns(new EditAdvertsViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);

            editAdvertPresenter.View_OnAdvertsGetData(null, EventArgs.Empty);

            advertServiceMock.Verify(a => a.GetAllAdverts(), Times.Once);
        }

        [TestCase("1.jpg")]
        [TestCase("100.jpg")]
        public void AddAdvertsToViewModel_WhenOnAdvertsGetDataEventIsRaised(string testPicturePath)
        {
            var editAdvertViewMock = new Mock<IEditAdvertsView>();
            editAdvertViewMock.SetupGet(view => view.Model).Returns(new EditAdvertsViewModel());

            var adverts = GetAdverts();
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(a => a.GetAllAdverts()).Returns(adverts);

            var editAdvertPresenter = new EditAdvertsPresenter(editAdvertViewMock.Object, advertServiceMock.Object);

            editAdvertPresenter.View_OnAdvertsGetData(null, EventArgs.Empty);
            
            editAdvertViewMock.Raise(v => v.OnAdvertsGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(adverts, editAdvertViewMock.Object.Model.Adverts);
        }

        private IQueryable<Advert> GetAdverts()
        {
            var adverts = new List<Advert>()
            {
                new Advert() {Title = "Title 1"},
                new Advert() {Title = "Title 2"},
            };

            return adverts.AsQueryable();
        }
    }
}
