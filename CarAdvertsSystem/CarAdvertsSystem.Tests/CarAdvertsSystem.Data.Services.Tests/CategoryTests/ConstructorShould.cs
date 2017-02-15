using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.CategoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateCategoryServices_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var categoryService = new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.That(categoryService, Is.InstanceOf<CategoryServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<Category>> mockedRepository = null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<NullReferenceException>(
                () => new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void Constuctor_Should_ThrowNullReferenceException_IfPassedUnitOfWorkIsNull()
        {
            var mockedRepository = new Mock<IRepository<Category>>();
            Mock<IUnitOfWork> mockedUnitOfWork = null;

            Assert.Throws<NullReferenceException>(
                () => new CategoryServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }
    }
}
