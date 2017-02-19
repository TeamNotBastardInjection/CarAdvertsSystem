using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CategoryTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            var category = new Mock<Category>();
            categoryService.GetById(category.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(category.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperCategoryWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            var categoryWithId = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            Assert.IsInstanceOf<Category>(categoryService.GetById(categoryWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            var categorytWithId = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(categorytWithId.Object.Id)).Returns(() => categorytWithId.Object);

            Assert.AreEqual(categoryService.GetById(categorytWithId.Object.Id), categorytWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfCategoryIsNull()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            Mock<Category> advertThatIsNull = null;

            Assert.Throws<NullReferenceException>(() => categoryService.GetById(advertThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoCategoryYolo()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(categoryService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectCategory_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();

            var categoryService = new CategoryServices(mockedRepository.Object);

            var category = new Mock<Category>();
            var secondCategory = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(category.Object.Id)).Returns(() => category.Object);

            Assert.AreNotEqual(categoryService.GetById(category.Object.Id), secondCategory.Object);
        }
    }
}
