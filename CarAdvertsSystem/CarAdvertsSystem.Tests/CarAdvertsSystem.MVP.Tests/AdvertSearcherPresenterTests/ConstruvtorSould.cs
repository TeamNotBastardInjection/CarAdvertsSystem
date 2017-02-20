using System;
using System.Reflection;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using NUnit.Framework;
using Moq;
using WebFormsMvp;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertSearcherPresenterTests
{
    [TestFixture]
    public class Construvtor_Sould
    {
        [Test]
        public void ThrowNullReferenceException_WhenISearchViewIsNull()
        {
            IAdvertSearcherView searchView = null;
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            Assert.That(
                () => new AdvertSearcherPresenter(searchView, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenICityServicesIsNull()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            ICityServices cityServiceMock = null;
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            Assert.That(
                () => new AdvertSearcherPresenter(searchView.Object, cityServiceMock, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenIVehicleModelServicesIsNull()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            IVehicleModelServices vehicleModelServiceMock = null;
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            Assert.That(
                () => new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock, manufacturerServiceMock.Object, categoryServiceMock.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenIManufacturerServicesIsNull()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            IManufacturerServices manufacturerServiceMock = null;
            var categoryServiceMock = new Mock<ICategoryServices>();

            Assert.That(
                () => new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock, categoryServiceMock.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenICategoryServicesIsNull()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            ICategoryServices categoryServiceMock = null;

            Assert.That(
                () => new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            Assert.That(actualInstance, Is.InstanceOf<Presenter<IAdvertSearcherView>>());
        }

        [Test]
        public void SetCorrectValueToCityServiceField()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var advertServiceField = typeof(AdvertSearcherPresenter).GetField("cityService", bindingFlags);
            var advertServiceFieldValue = advertServiceField.GetValue(actualInstance);

            Assert.That(advertServiceFieldValue, Is.Not.Null);
        }

        [Test]
        public void SetCorrectValueToVehicleModelServiceField()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var advertServiceField = typeof(AdvertSearcherPresenter).GetField("vehicleModelService", bindingFlags);
            var advertServiceFieldValue = advertServiceField.GetValue(actualInstance);

            Assert.That(advertServiceFieldValue, Is.Not.Null);
        }

        [Test]
        public void SetCorrectValueToManufacturerServiceField()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var advertServiceField = typeof(AdvertSearcherPresenter).GetField("manufacturerService", bindingFlags);
            var advertServiceFieldValue = advertServiceField.GetValue(actualInstance);

            Assert.That(advertServiceFieldValue, Is.Not.Null);
        }

        [Test]
        public void SetCorrectValueToCategoryServiceField()
        {
            var searchView = new Mock<IAdvertSearcherView>();
            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var actualInstance = new AdvertSearcherPresenter(searchView.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var advertServiceField = typeof(AdvertSearcherPresenter).GetField("categoryService", bindingFlags);
            var advertServiceFieldValue = advertServiceField.GetValue(actualInstance);

            Assert.That(advertServiceFieldValue, Is.Not.Null);
        }
    }
}
