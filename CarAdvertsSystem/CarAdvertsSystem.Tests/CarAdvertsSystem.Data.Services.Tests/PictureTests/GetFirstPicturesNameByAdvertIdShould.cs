using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.PictureTests
{
    [TestFixture]
    public class GetFirstPicturesNameByAdvertIdShould
    {
        [Test]
        public void ReturnCorrectString_WhenValidIdParameter()
        {
            var mockedRepository = new Mock<IRepository<Picture>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pictureService = new PictureServices(mockedRepository.Object, mockedUnitOfWork.Object);

            int advertId = 1;
            string expectedResult = "1.jpg";

            mockedRepository.Setup(rep => rep.All()).Returns(() => new List<Picture>() {
                new Picture() { Id = 1, Name = expectedResult, AdvertId = 1 },
                new Picture() { Id = 2, Name = "2.jpg" },
                new Picture() { Id = 3, Name = "3.jpg", AdvertId = 1 },
                new Picture() { Id = 4, Name = "4.jpg" }
            }.AsQueryable());

            // Act
            var result = pictureService.GetFirstPicturesNameByAdvertId(advertId);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ReturnNull_WhenValidIdParameterAndAdvertHasNotPictures()
        {
            var mockedRepository = new Mock<IRepository<Picture>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pictureService = new PictureServices(mockedRepository.Object, mockedUnitOfWork.Object);

            int testAdvertId = 2;

            mockedRepository.Setup(rep => rep.All()).Returns(() => new List<Picture>() {
                new Picture() { Id = 1, Name = "1.jpg", AdvertId = 1 },
                new Picture() { Id = 2, Name = "2.jpg" },
                new Picture() { Id = 3, Name = "3.jpg", AdvertId = 1 },
                new Picture() { Id = 4, Name = "4.jpg" }
            }.AsQueryable());

            // Act
            var result = pictureService.GetFirstPicturesNameByAdvertId(testAdvertId);

            Assert.AreEqual(null, result);
        }
    }
}
