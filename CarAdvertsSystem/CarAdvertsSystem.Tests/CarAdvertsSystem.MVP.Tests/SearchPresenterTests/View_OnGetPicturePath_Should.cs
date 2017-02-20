using System;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.Search;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.SearchPresenterTests
{
    [TestFixture]
    public class View_OnGetPicturePath_Should
    {
        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenGetPicturePathEventArgsAdvertIdPropertyIsNotPositive(int invalidADvertId)
        {
            var searchViewMock = new Mock<ISearchView>();
            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);
            
            var getPicturePathEvetnArgs = new GetPicturePathEventArgs(invalidADvertId);

            Assert.That(
                () => searcherPresenter.View_OnGetPicturePath(null, getPicturePathEvetnArgs),
                Throws.InstanceOf<ArgumentException>());
        }

        //[TestCase(1)]
        //[TestCase(42)]
        //[TestCase(int.MaxValue)]
        //public void ShouldNotThrowArgumentExceptionWithCorrectMessage_WhenGetPicturePathEventArgsAdvertIdPropertyIsPositive(int validADvertId)
        //{
        //    var searchViewMock = new Mock<ISearchView>();
        //    var advertServiceMock = new Mock<IAdvertServices>();
        //    var pictureServiceMock = new Mock<IPictureServices>();

        //    var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);
        //    object sender = new object();
        //    var getPicturePathEvetnArgs = new GetPicturePathEventArgs(validADvertId);

        //    Assert.That(
        //        () => searcherPresenter.View_OnGetPicturePath(sender, getPicturePathEvetnArgs),
        //        Throws.Nothing);
        //}

        [Test]
        public void InvokeIPictureService_GetFirstPicturesNameByAdvertIdMethodOnce()
        {
            var searchViewMock = new Mock<ISearchView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new SearchViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            var pictureServiceMock = new Mock<IPictureServices>();

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);
            
            var getPicturePathEvetnArgs = new GetPicturePathEventArgs(3);

            searcherPresenter.View_OnGetPicturePath(null, getPicturePathEvetnArgs);

            pictureServiceMock.Verify(service => service.GetFirstPicturesNameByAdvertId(It.IsAny<int>()), Times.Once);
        }
        
        [TestCase("1.jpg")]
        [TestCase("100.jpg")]
        public void AddPicturePathToViewModel_WhenOnGetPicturePathEventIsRaised(string testPicturePath)
        {
            // Arrange
            var searchViewMock = new Mock<ISearchView>();
            searchViewMock.SetupGet(view => view.Model).Returns(new SearchViewModel());

            var advertServiceMock = new Mock<IAdvertServices>();
            
            var pictureServiceMock = new Mock<IPictureServices>();
            pictureServiceMock.Setup(p => p.GetFirstPicturesNameByAdvertId(It.IsAny<int>())).Returns(testPicturePath);

            var searcherPresenter = new SearcherPresenter(searchViewMock.Object, advertServiceMock.Object, pictureServiceMock.Object);

            var getPictureEvetnArgs = new GetPicturePathEventArgs(3);

            // Act
            searchViewMock.Raise(v => v.OnGetPicturePath += null, getPictureEvetnArgs);

            // Assert
            CollectionAssert.AreEquivalent(testPicturePath, searchViewMock.Object.Model.PicturePath);
        }
        
    }
}
