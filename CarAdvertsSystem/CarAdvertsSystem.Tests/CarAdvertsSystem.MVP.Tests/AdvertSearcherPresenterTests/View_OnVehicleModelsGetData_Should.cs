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
    public class View_OnVehicleModelsGetData_Should
    {
        [Test]
        public void InvokeIVehicleModelService_GetAllVehicleModelsMethodOnce()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searcherPresenter.View_OnVehicleModelsGetData(null, EventArgs.Empty);

            vehicleModelServiceMock.Verify(service => service.GetAllVehicleModels(), Times.Once);
        }

        [Test]
        public void AddVehicleModelsToViewModel_WhenOnVehicleModelsGetDataEventIsRaised()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            
            var vehicleModels = this.GetModels();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            vehicleModelServiceMock.Setup(c => c.GetAllVehicleModels()).Returns(vehicleModels);

            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            searchViewMock.Raise(v => v.OnVehicleModelsGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(vehicleModels, searchViewMock.Object.Model.VehicleModels);
        }

        private IQueryable<VehicleModel> GetModels()
        {
            var models = new List<VehicleModel>()
            {
                new VehicleModel() { Name = "A4"},
                new VehicleModel() { Name = "A6"},
                new VehicleModel() { Name = "A8"},
            };

            return models.AsQueryable();
        }
    }
}
