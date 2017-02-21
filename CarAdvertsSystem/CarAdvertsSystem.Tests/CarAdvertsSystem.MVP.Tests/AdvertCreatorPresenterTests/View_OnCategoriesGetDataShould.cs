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

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertCreatorPresenterTests
{
    [TestFixture]
    public class View_OnCategoriesGetData_Should
    {
        [Test]
        public void InvokeICategoryService_GetAllCategoriesMethodOnce()
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

            advertCreatorPresenter.View_OnCategoriesGetData(null, EventArgs.Empty);

            categoryServiceMock.Verify(service => service.GetAllCategories(), Times.Once);
        }

        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            var advertCreatorView = new Mock<IAdvertCreatorView>();
            advertCreatorView.SetupGet(view => view.Model).Returns(new AdvertCreatorViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();

            var categories = this.GetCategories();
            var categoryServiceMock = new Mock<ICategoryServices>();
            categoryServiceMock.Setup(c => c.GetAllCategories()).Returns(categories);

            var advertServiceMock = new Mock<IAdvertServices>();

            var advertCreatorPresenter = new AdvertCreatorPresenter(
                advertCreatorView.Object,
                cityServiceMock.Object,
                manufacturerServiceMock.Object,
                vehicleModelServiceMock.Object,
                categoryServiceMock.Object,
                advertServiceMock.Object);
            
            advertCreatorView.Raise(v => v.OnCategoriesGetData += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(categories, advertCreatorView.Object.Model.Categories);
        }

        private IQueryable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category() { Name = "Car"},
                new Category() { Name = "Bus"},
                new Category() { Name = "Caravan"},
            };

            return categories.AsQueryable();
        }

    }
}
