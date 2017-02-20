using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.Search;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.SearchPresenterTests
{
    [TestFixture]
    public class View_OnSearchAdverts_Should
    {
        [TestCase(0)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenVehicleModelIdPropertyIsNotPositive(int invalidVehicleModelId)
        {
            int vehicleId = invalidVehicleModelId;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = 3;
            
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(0)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenCityIdPropertyIsNotPositive(int invalidCityId)
        {
            int vehicleId = 3;
            int cityId = invalidCityId;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = 3;

            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenMinPricePropertyIsNotPositive(int testMinPrice)
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = testMinPrice;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = 3;

            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenMaxPricePropertyIsNotPositive(int testMaxPrice)
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = testMaxPrice;
            int yearFrom = 3;
            int yearTo = 3;

            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenYearFromPropertyIsNotPositive(int testYearFrom)
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = testYearFrom;
            int yearTo = 3;

            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenYearToPropertyIsNotPositive(int testYearTo)
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = testYearTo;

            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            Assert.That(
                () => searcherPresenter.View_OnSearchAdverts(null, searchEventArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void InvokeAdvertService_GetAdvertsByMultipleParametersMethodOnce()
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = 3;

            var searchViewMock = new Mock<ISearchView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new SearchViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            searcherPresenter.View_OnSearchAdverts(null, searchEventArgs);

            advertServiceMock.Verify(service => service.GetAdvertsByMultipleParameters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void AddAdvertsToViewModel_WhenOnSearchAdvertsEventIsRaised()
        {
            int vehicleId = 3;
            int cityId = 3;
            int minPrice = 3;
            int maxPrice = 3;
            int yearFrom = 3;
            int yearTo = 3;

            // Arrange
            var searchViewMock = new Mock<ISearchView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new SearchViewModel());

            var adverts = this.GetAdverts();
            var advertServiceMock = new Mock<IAdvertServices>();
            advertServiceMock.Setup(p => p.GetAdvertsByMultipleParameters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                             .Returns(adverts);

            var pictureServiceMock = new Mock<IPictureServices>();
            

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var searchEventArgs = new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vehicleId);

            // Act
            searchViewMock.Raise(v => v.OnSearchAdverts += null, searchEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(adverts, searchViewMock.Object.Model.Adverts);
        }

        private IQueryable<Advert> GetAdverts()
        {
            var adverts = new List<Advert>()
            {
                new Advert()
                {
                    CityId = 3,
                    Description = "description",
                    DistanceCoverage = 3,
                    Power = 1000,
                    Price = 1000,
                    Title = "Advert1"
                },
                new Advert()
                {
                    CityId = 2,
                    Description = "description",
                    DistanceCoverage = 4,
                    Power = 1000,
                    Price = 1000,
                    Title = "Advert2"
                },
                new Advert()
                {
                    CityId = 3,
                    Description = "description",
                    DistanceCoverage = 3,
                    Power = 1000,
                    Price = 1000,
                    Title = "Advert3"
                }
            };

            return adverts.AsQueryable();
        }
    }
}
