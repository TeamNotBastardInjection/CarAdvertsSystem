using System.Data.Entity;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models.Contracts;
using CarAdvertsSystem.Data.Repositories;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ConstructorShould_ReturnNewInstanceOfGenericRepo_IfParamsAreValid()
        {
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

            var repository = new GenericRepository<IAdvert>(mockedContext.Object);

            Assert.That(repository, Is.Not.Null);
        }

        [Test]
        public void ConstructorShould_ShouldThrowArgumentNullException_IfPassedContextIsNullWithAppropriateMessage()
        {
            ICarAdvertsSystemDbContext contextThatIsNull = null;

            Assert.That(() => new GenericRepository<IAdvert>(contextThatIsNull), 
                Throws.ArgumentNullException.With.Message.Contains
                ("An instance of DbContext is required to use this repository."));
        }

        [Test]
        public void ConstructorShould_ReturnCorrectContext_IfValidParamsPassed()
        {
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

            var repository = new GenericRepository<IAdvert>(mockedContext.Object);

            Assert.That(repository.Context, Is.Not.Null);
            Assert.That(repository.Context, Is.EqualTo(mockedContext.Object));
        }
    }
}
