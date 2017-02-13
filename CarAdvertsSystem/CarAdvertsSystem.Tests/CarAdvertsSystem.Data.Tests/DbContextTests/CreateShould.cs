using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Contracts;

using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.DbContextTests
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void DbContextCreate_Should_ReturnANewInstanceOfTheDbContext()
        {
            var context = CarAdvertsSystemDbContext.Create();

            Assert.IsNotNull(context);
        }

        [Test]
        public void DbContextCreate_Should_ReturnANewInstanceOfTheDbContextSecondCase()
        {
            var context = CarAdvertsSystemDbContext.Create();

            Assert.IsInstanceOf<ICarAdvertsSystemDbContext>(context);
        }
    }
}
