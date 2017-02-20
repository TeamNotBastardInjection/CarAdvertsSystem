using System;

using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertCreator;

using NUnit.Framework;
using Moq;
using WebFormsMvp;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertCreatorPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceException_WhenIAdvertCreatorViewIsNull()
        {
            IAdvertCreatorView advertCreatorView = null;
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            Assert.That(
                () => new AdvertCreatorPresenter(
                    advertCreatorView,
                    cityService.Object,
                    manufacturerService.Object,
                    vehicleModelService.Object,
                    categoryService.Object,
                    advertService.Object),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenCityServiceIsNull()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            ICityServices cityService = null;
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            Assert.That(() => new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService.Object,
                advertService.Object),
                Throws.ArgumentNullException.With.Message.Contains("City Service is null!!!"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenManufactureServiceIsNull()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            IManufacturerServices manufacturerService = null;
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            Assert.That(() => new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService,
                vehicleModelService.Object,
                categoryService.Object,
                advertService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Manufacturer Service is null!!!"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenVehicleModelServiceIsNull()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            IVehicleModelServices vehicleModelService = null;
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            Assert.That(() => new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService,
                categoryService.Object,
                advertService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Vehicle Model Service is null!!!"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenCategoryServiceIsNull()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            ICategoryServices categoryService = null;
            var advertService = new Mock<IAdvertServices>();

            Assert.That(() => new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService,
                advertService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Category Service is null!!!"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessage_WhenAdvertServiceIsNull()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            IAdvertServices advertService = null;

            Assert.That(() => new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService.Object,
                advertService),
                Throws.ArgumentNullException.With.Message.Contains("Advert Service is Null!!!"));
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            var advertCreatorPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService.Object,
                advertService.Object);

            Assert.That(advertCreatorPresenter, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            var cityService = new Mock<ICityServices>();
            var manufacturerService = new Mock<IManufacturerServices>();
            var vehicleModelService = new Mock<IVehicleModelServices>();
            var categoryService = new Mock<ICategoryServices>();
            var advertService = new Mock<IAdvertServices>();

            var advertCreatorPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityService.Object,
                manufacturerService.Object,
                vehicleModelService.Object,
                categoryService.Object,
                advertService.Object);

            Assert.That(advertCreatorPresenter, Is.InstanceOf<Presenter<IAdvertCreatorView>>());
        }
    }
}
