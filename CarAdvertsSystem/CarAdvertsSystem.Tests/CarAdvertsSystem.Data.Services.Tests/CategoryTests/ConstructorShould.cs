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

            var categoryService = new CategoryServices(mockedRepository.Object);

            Assert.That(categoryService, Is.InstanceOf<CategoryServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<Category>> mockedRepository = null;

            Assert.Throws<NullReferenceException>(
                () => new CategoryServices(mockedRepository.Object));
        }
    }
}
