using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.UnitOfWork;

using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class DisposeShould
    {
        [Test]
        public void Dispose_Should_BeCalledNever()
        {
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();
            var unitOfWork = new UnitOfWork(dbContext.Object);

            unitOfWork.Dispose();

            dbContext.Verify(u => u.Dispose(), Times.Never);
        }
    }
}
