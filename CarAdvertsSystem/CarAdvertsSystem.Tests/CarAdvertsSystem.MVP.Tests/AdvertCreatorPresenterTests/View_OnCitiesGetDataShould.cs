using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertCreator;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using NUnit.Framework;
using Moq;
using NUnit.Framework.Internal;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertCreatorPresenterTests
{
    [TestFixture]
    public class View_OnCitiesGetData_Should
    {

        [Test]
        public void InvokeICityService_GetAllCitiesMethodOnce()
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

            advertCreatorPresenter.View_OnCitiesGetData(null, EventArgs.Empty);

            cityServiceMock.Verify(service => service.GetAllCities(), Times.Once);
        }



        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var cities = this.GetCities();
            var cityServiceMock = new Mock<ICityServices>();
            cityServiceMock.Setup(c => c.GetAllCities()).Returns(cities);
            
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

            advertCreatorView.Raise(v => v.OnCitiesGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(cities, advertCreatorView.Object.Model.Cities);
        }

        private IQueryable<City> GetCities()
        {
            var cities = new List<City>()
            {
                new City() { Name = "Sofia"},
                new City() { Name = "Plovdiv"},
                new City() { Name = "Varna"},
            };

            return cities.AsQueryable();
        }

    }
}
