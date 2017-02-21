using System;
using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertCreator;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertCreatorPresenterTests
{
    [TestFixture]
    public class View_OnManufacturersGetData_Should
    {
        [Test]
        public void InvokeIManufacturerService_GetAllManufacturersMethodOnce()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();
            var advertServiceMock = new Mock<IAdvertServices>();

            var advertCreatorPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityServiceMock.Object,
                manufacturerServiceMock.Object,
                vehicleModelServiceMock.Object,
                categoryServiceMock.Object,
                advertServiceMock.Object);

            advertCreatorPresenter.View_OnManufacturersGetData(null, EventArgs.Empty);

            manufacturerServiceMock.Verify(service => service.GetAllManufacturers(), Times.Once);
        }

        [Test]
        public void AddManufacturersToViewModel_WhenOnManufakturerGetDataEventIsRaised()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();

            var manufacturers = this.GetManufacturers();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            manufacturerServiceMock.Setup(c => c.GetAllManufacturers()).Returns(manufacturers);

            var categoryServiceMock = new Mock<ICategoryServices>();
            var advertServiceMock = new Mock<IAdvertServices>();

            var advertCreatorPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityServiceMock.Object,
                manufacturerServiceMock.Object,
                vehicleModelServiceMock.Object,
                categoryServiceMock.Object,
                advertServiceMock.Object);

            advertCreatorView.Raise(v => v.OnManufacturersGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(manufacturers, advertCreatorView.Object.Model.Manufacturers);
        }

        private IQueryable<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Name = "Audi"},
                new Manufacturer() { Name = "Fiat"},
                new Manufacturer() { Name = "Ferrary"},
            };

            return manufacturers.AsQueryable();
        }
    }
}
