using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using CarAdvertsSystem.MVP.Search;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.AdvertSearcherPresenterTests
{
    [TestFixture]
    public class View_OnCategoriesGetData_Should
    {
        [Test]
        public void InvokeICityrService_GetAllCategoriesMethodOnce()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);
            
            searcherPresenter.View_OnCategoriesGetData(null, EventArgs.Empty);

            categoryServiceMock.Verify(service => service.GetAllCategories(), Times.Once);
        }

        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            var searchViewMock = new Mock<IAdvertSearcherView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new AdvertSearcherViewModel());

            var cityServiceMock = new Mock<ICityServices>();
            var vehicleModelServiceMock = new Mock<IVehicleModelServices>();
            var manufacturerServiceMock = new Mock<IManufacturerServices>();
            var categoryServiceMock = new Mock<ICategoryServices>();

            var categories = this.GetCategories();
            categoryServiceMock.Setup(c => c.GetAllCategories()).Returns(categories);

            var searcherPresenter = new AdvertSearcherPresenter(searchViewMock.Object, cityServiceMock.Object, vehicleModelServiceMock.Object, manufacturerServiceMock.Object, categoryServiceMock.Object);
            
            searchViewMock.Raise(v => v.OnCategoriesGetData += null, EventArgs.Empty);
            
            CollectionAssert.AreEquivalent(categories, searchViewMock.Object.Model.Categories);
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
