using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChangesShould
    {
        [Test]
        public void SaveChanges_Should_CallSaveChangesOnce()
        {
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();
            var unitOfWork = new UnitOfWork(dbContext.Object);

            unitOfWork.SaveChanges();

            dbContext.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
