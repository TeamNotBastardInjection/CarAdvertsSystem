using System.Linq;
using NUnit.Framework;
using CarAdvertsSystem.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdvertsSystem.Common.Constants;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Models.Tests.VehicleModelsTests
{
    public class VehicleModelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(VehicleModel).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var userAnimal = new VehicleModel { Id = testId };

            //Assert
            Assert.AreEqual(testId, userAnimal.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.VechicleNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.VechicleNameMaxLength));
        }

        [TestCase("A4")]
        [TestCase("Tigra")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var VehicleModel = new VehicleModel { Name = testName };

            //Assert
            Assert.AreEqual(VehicleModel.Name, testName);
        }
        
        [TestCase(15)]
        [TestCase(20)]
        public void ManufacturerId_ShouldGetAndSetDataCorrectly(int testManufacturerId)
        {
            // Arrange & Act
            var VehicleModel = new VehicleModel { ManufacturerId = testManufacturerId };

            //Assert
            Assert.AreEqual(VehicleModel.ManufacturerId, testManufacturerId);
        }

        [TestCase("Audi")]
        [TestCase("Fiat")]
        public void Manufacturer_ShouldGetAndSetDataCorrectly(string testManufacturerName)
        {
            // Arrange & Act         
            var manufacturer = new Manufacturer() { Name = testManufacturerName };
            var vehicleModel = new VehicleModel { Manufacturer = manufacturer };

            //Assert
            Assert.AreEqual(vehicleModel.Manufacturer.Name, testManufacturerName);
        }

        // I should add tests form categories and adverts
    }
}
