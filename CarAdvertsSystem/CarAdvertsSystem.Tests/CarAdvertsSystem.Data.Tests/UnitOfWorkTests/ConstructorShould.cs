using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Contructor_Should_ThrowArgumentNullException_IfPassedDbContextIsNull()
        {
            ICarAdvertsSystemDbContext dbContextThatIsNull = null;

            Assert.That(
                () => new UnitOfWork(dbContextThatIsNull),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void Contructor_Should_NotThrowArgumentNullException_IfPassedDbContextIsNotNull()
        {
            var validDbContext = new Mock<ICarAdvertsSystemDbContext>();
            var unitOfWork = new UnitOfWork(validDbContext.Object);

            Assert.That(unitOfWork, Is.Not.Null);
        }

        [Test]
        public void Contructor_Should_CreateIDisposableObj_IfPassedDbContextIsValid()
        {
            var validDbContext = new Mock<ICarAdvertsSystemDbContext>();
            var unitOfWork = new UnitOfWork(validDbContext.Object);

            Assert.That(unitOfWork, Is.InstanceOf<IDisposable>());
        }
    }
}
