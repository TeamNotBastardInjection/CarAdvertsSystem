using System.Collections.Generic;

using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertCreator;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertCreatorPresenterTests
{
    [TestFixture]
    public class View_OnCreateAdvert_Should
    {
        [Test]
        public void Invoke_AdvertService_AddAdvertMethodOnce()
        {
            var title = "Ebasi Mamata";
            var userId = "asdasjd-asjkdasjd-asdasd";
            var cityId = 2;
            var vehicleModelId = 2;
            var price = 222;
            var power = 437;
            var distanceCoverage = 250000;
            var description = "Golqm Chuk";
            var year = 2017;
            var pictures = new List<string>() {"1.jpg"};

            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var advertService = new Mock<IAdvertServices>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();

            var advertCreaterPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService.Object,
                advertService.Object);

            var createAdvertEventArgs = new CreateAdvertEventArgs(
                title,
                userId,
                cityId,
                vehicleModelId,
                price,
                power,
                distanceCoverage,
                description,
                year,
                pictures);

            advertCreaterPresenter.View_OnCreateAdvert(null, createAdvertEventArgs);

            advertService.Verify(service => service.AddAdvert(It.IsAny<Advert>()), Times.Once);
        }
    }
}