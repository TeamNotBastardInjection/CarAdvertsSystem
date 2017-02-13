using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Contracts;

using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Tests.DbContextTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void DbContextConstructor_Should_HaveParameterlessConstructor()
        {
            var dbContext = new CarAdvertsSystemDbContext();

            Assert.IsInstanceOf<CarAdvertsSystemDbContext>(dbContext);
        }

        [Test]
        public void DbContextConstructor_Should_ReturnInstanceOfIt()
        {
            var dbContext = new CarAdvertsSystemDbContext();

            Assert.IsInstanceOf<ICarAdvertsSystemDbContext>(dbContext);
        }
    }
}
