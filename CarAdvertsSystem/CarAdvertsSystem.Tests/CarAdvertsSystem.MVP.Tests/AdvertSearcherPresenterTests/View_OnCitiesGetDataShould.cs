using System;
using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertSearcherPresenterTests
{
    [TestFixture]
    public class View_OnCitiesGetData_Should
    {
        [Test]
        public void InvokeICityService_GetAllCitiesMethodOnce()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searcherPresenter.View_OnCitiesGetData(null, EventArgs.Empty);

            cityServiceMock.Verify(service => service.GetAllCities(), Times.Once);
        }

        [Test]
        public void AddCitiesToViewModel_WhenOnCitiesGetDataEventIsRaised()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());
            
            var cityServiceMock = new Mock<ICityServices>();
            var cities = this.GetCities();
            cityServiceMock.Setup(c => c.GetAllCities()).Returns(cities);

            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();
            
            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searchViewMock.Raise(v => v.OnCitiesGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(cities, searchViewMock.Object.Model.Cities);
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
