using System;
using System.Collections.Generic;
using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CategoryTests
{
    [TestFixture]
    public class GetAllCategoriesShould
    {
        [Test]
        public void GetAllCategoriesShould_BeCalled_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            categoryService.GetAllCategories();

            mockedRepository.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllCategories_Should_NotBeCalled_IfItIsNeverCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            mockedRepository.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllCategories_Should_ReturnIQueryable_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Category> expectedCategoriesResult = new List<Category>() { new Category(), new Category() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            Assert.IsInstanceOf<IQueryable<Category>>(categoryService.GetAllCategories());
        }

        [Test]
        public void GetAllCategories_Should_DoItsJobCorrectly_IfCalled()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Category> expectedCategoriesResult = new List<Category>() { new Category(), new Category() };
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            Assert.AreEqual(categoryService.GetAllCategories(), expectedCategoriesResult);
        }

        [Test]
        public void GetAllCategories_Should_ReturnEmptyCollection_IfThereAreNoAdvertsAdded()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Category> expectedCategoriesResult = new List<Category>();
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            Assert.IsEmpty(categoryService.GetAllCategories());
        }

        [Test]
        public void GetAllCategories_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            IEnumerable<Category> expectedCategoriesResult = null;
            mockedRepository.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            Assert.Throws<ArgumentNullException>(() => categoryService.GetAllCategories());
        }
    }
}
