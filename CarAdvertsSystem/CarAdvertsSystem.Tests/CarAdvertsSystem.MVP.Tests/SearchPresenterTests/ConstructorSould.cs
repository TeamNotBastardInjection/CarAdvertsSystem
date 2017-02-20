using System;
using System.Reflection;
using CarAdvertsSystem.Data.Services.Contracts;
using NUnit.Framework;
using Moq;
using CarAdvertsSystem.MVP.Search;
using WebFormsMvp;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.SearchPresenterTests
{
    [TestFixture]
    public class Constructor_Sould
    {
        [Test]
        public void ThrowNullReferenceException_WhenISearchViewIsNull()
        {
            ISearchView searchView = null;
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            Assert.That(
                () => new SearcherPresenter(searchView, advertServiceMock.Object, pictureServiceMock.Object),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenIAdvertServicesIsNull()
        {
            var searchViewMock = new Mock<ISearchView>();
            IAdvertServices advertServiceMock = null;
            var pictureServiceMock = new Mock<IPictureServices>();

            Assert.That(
                () => new SearcherPresenter(searchViewMock.Object, advertServiceMock, pictureServiceMock.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenIPictureServicesIsNull()
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            IPictureServices pictureServiceMock = null;

            Assert.That(
                () => new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);
            
            Assert.That(actualInstance, Is.InstanceOf<Presenter<ISearchView>>());
        }

        
        //[Test]
        //public void SubscribeToViewGetTopDishesEvent()
        //{
        //    var topDishesView = new FakeTopDishesView();
        //    var dishesService = new Mock<IDishesAsyncService>();

        //    var actualInstance = new TopDishesPresenter(topDishesView, dishesService.Object);

        //    Assert.That(topDishesView.ContainsSubscribedMethod("OnGetTopDishes"), Is.True);
        //}

        [Test]
        public void SetCorrectValueToAdvertServiceField()
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var advertServiceField = typeof(SearcherPresenter).GetField("advertService", bindingFlags);
            var advertServiceFieldValue = advertServiceField.GetValue(actualInstance);

            Assert.That(advertServiceFieldValue, Is.Not.Null);
        }

        [Test]
        public void SetCorrectValueToPictureServicesField()
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var pictureSerrviceField = typeof(SearcherPresenter).GetField("pictureSerrvice", bindingFlags);
            var pictureSerrvice = pictureSerrviceField.GetValue(actualInstance);

            Assert.That(pictureSerrvice, Is.Not.Null);
        }

        //[Test]
        //public void IAdvertServiceField_ShouldBeDeclaredOfCorrectType()
        //{
        //    var searchViewMock = new Mock<ISearchView>();
        //    var advertServiceMock = new Mock<IAdvertServices>();
        //    var pictureServiceMock = new Mock<IPictureServices>();

        //    var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

        //    var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        //    var advertServiceField = typeof(SearcherPresenter).GetField("advertService", bindingFlags);

        //    Assert.That(advertServiceField.FieldType, Is.EqualTo(typeof(IAdvertServices)));
        //}

        //[Test]
        //public void IPictureServiceField_ShouldBeDeclaredOfCorrectType()
        //{
        //    var searchViewMock = new Mock<ISearchView>();
        //    var advertServiceMock = new Mock<IAdvertServices>();
        //    var pictureServiceMock = new Mock<IPictureServices>();

        //    var actualInstance = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

        //    var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        //    var pictureSerrviceField = typeof(SearcherPresenter).GetField("pictureSerrvice", bindingFlags);

        //    Assert.That(pictureSerrviceField.FieldType, Is.EqualTo(typeof(IPictureServices)));
        //}
    }
}