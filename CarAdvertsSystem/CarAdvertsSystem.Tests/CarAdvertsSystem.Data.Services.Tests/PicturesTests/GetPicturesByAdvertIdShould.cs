using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.PictureTests
{
    [TestFixture]
    public class GetPicturesByAdvertIdShould
    {
        [Test]
        public void ReturnCorrectPictureCount_WhenValidAdvertIdParameter()
        {
            var mockedRepository = new Mock<IRepository<Picture>>();
            var pictureService = new PictureServices(mockedRepository.Object);

            int testAdvertId = 1;
            var expectedResult = 2;

            mockedRepository.Setup(rep => rep.All()).Returns(() => new List<Picture>() {
                new Picture() { Id = 1, Name = "1.jpg", AdvertId = 1 },
                new Picture() { Id = 2, Name = "2.jpg", AdvertId = 2},
                new Picture() { Id = 3, Name = "3.jpg", AdvertId = 1 },
                new Picture() { Id = 4, Name = "4.jpg", AdvertId = 3}
            }.AsQueryable());

            // Act
            var result = pictureService.GetPicturesByAdvertId(testAdvertId);

            Assert.AreEqual(expectedResult, result.ToList().Count);
        }

    }
}
