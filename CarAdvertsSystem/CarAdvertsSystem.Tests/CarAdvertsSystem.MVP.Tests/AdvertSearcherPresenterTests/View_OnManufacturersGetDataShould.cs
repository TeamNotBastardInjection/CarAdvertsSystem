using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertSearcherPresenterTests
{
    [TestFixture]
    public class View_OnManufacturersGetData_Should
    {
        //[Test]
        //public void GetAndSetCorrect

        [Test]
        public void InvokeIManufacturerService_GetAllManufacturersMethodOnce()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searcherPresenter.View_OnManufacturersGetData(null, EventArgs.Empty);

            manufacturerServiceMock.Verify(service => service.GetAllManufacturers(), Times.Once);
        }

        [Test]
        public void AddManufacturersToViewModel_WheOnManufacturersGetDataEventIsRaised()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var manufacturers = this.GetManufacturers();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            manufacturerServiceMock.Setup(c => c.GetAllManufacturers()).Returns(manufacturers);
            
            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searchViewMock.Raise(v => v.OnManufacturersGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(manufacturers, searchViewMock.Object.Model.Manufacturers);
        }

        private IQueryable<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Name = "Audi"},
                new Manufacturer() { Name = "Paugeot"},
                new Manufacturer() { Name = "Citroen"},
            };

            return manufacturers.AsQueryable();
        }

    }
}
