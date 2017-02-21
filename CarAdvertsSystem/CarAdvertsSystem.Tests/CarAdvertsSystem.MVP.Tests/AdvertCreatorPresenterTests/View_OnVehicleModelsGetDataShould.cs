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
    public class View_OnVehicleModelsGetData_Should
    {
        [Test]
        public void InvokeIVehicleModelService_GetAllVehicleModelsMethodOnce()
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

            advertCreatorPresenter.View_OnVehicleModelsGetData(null, EventArgs.Empty);

            vehicleModelServiceMock.Verify(service => service.GetAllVehicleModels(), Times.Once);
        }

        [Test]
        public void AddVehicleModelsToViewModel_WhenOnVehicleModelsGetDataEventIsRaised()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var cityServiceMock = new Mock<ICityServices>();

            var vehicleModels = this.GetVehicleModels();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            vehicleModelServiceMock.Setup(c => c.GetAllVehicleModels()).Returns(vehicleModels);
            
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

            advertCreatorView.Raise(v => v.OnVehicleModelsGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(vehicleModels, advertCreatorView.Object.Model.VehicleModels);
        }

        private IQueryable<VehicleModel> GetVehicleModels()
        {
            var vehicleModels = new List<VehicleModel>()
            {
                new VehicleModel() { Name = "A4"},
                new VehicleModel() { Name = "A6"},
                new VehicleModel() { Name = "A8"},
            };

            return vehicleModels.AsQueryable();
        }
    }
}
