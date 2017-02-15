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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var category = new Mock<Category>();
            categoryService.GetById(category.Object.Id);

            mockedRepository.Verify(rep => rep.GetById(category.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperAdvertWithId_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var categoryWithId = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            Assert.IsInstanceOf<Category>(categoryService.GetById(categoryWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var categorytWithId = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(categorytWithId.Object.Id)).Returns(() => categorytWithId.Object);

            Assert.AreEqual(categoryService.GetById(categorytWithId.Object.Id), categorytWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<Category> advertThatIsNull = null;

            Assert.Throws<NullReferenceException>(() => categoryService.GetById(advertThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoAdvertYolo()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Setup(rep => rep.GetById(0)).Returns(() => null);

            Assert.IsNull(categoryService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectAdvert_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            var category = new Mock<Category>();
            var secondCategory = new Mock<Category>();
            mockedRepository.Setup(rep => rep.GetById(category.Object.Id)).Returns(() => category.Object);

            Assert.AreNotEqual(categoryService.GetById(category.Object.Id), secondCategory.Object);
        }
    }
}
