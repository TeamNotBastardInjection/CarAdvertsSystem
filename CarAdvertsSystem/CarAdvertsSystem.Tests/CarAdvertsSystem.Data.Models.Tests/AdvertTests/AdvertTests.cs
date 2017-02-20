using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Common.Constants;

using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Models.Tests.AdvertTests
{
    [TestFixture]
    public class AdvertTests
    {
        [Test]
        public void IdKey_ShouldHaveTheKeyAttribute()
        {
            var keyAttributeProperty = typeof(Advert).GetProperty("Id");

            var attribute = keyAttributeProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Id_ShouldSetIdCorrectly(int testId)
        {
            var advert = new Advert {Id = testId};

            Assert.AreEqual(testId, advert.Id);
        }

        [Test]
        public void Title_ShouldHaveTheRequiredAttribute()
        {
            var titleProp = typeof(Advert).GetProperty("Title");

            var requiredAttribute = titleProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_ShouldHaveTheCorrectMinLength()
        {
            var titleProp = typeof(Advert).GetProperty("Title");

            var minLengthAttribute = titleProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertTitleMinLength));
        }

        [Test]
        public void Title_ShouldHaveTheCorrectMaxLength()
        {
            var titleProp = typeof(Advert).GetProperty("Title");

            var maxLengthAttribute = titleProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertTitleMaxLength));
        }

        [TestCase("Best Scrap Car Brah!")]
        [TestCase("Best Hypercar Car Brah!")]
        public void Title_ShouldSetTitleDataCorrectly(string testTitle)
        {
            var advert = new Advert {Title = testTitle};

            Assert.AreEqual(testTitle, advert.Title);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var advert = new Advert {IsDeleted = testIsDeleted};

            Assert.AreEqual(testIsDeleted, advert.IsDeleted);
        }

        [Test]
        public void Year_ShouldHaveRequiredAttribute()
        {
            var yearProp = typeof(Advert).GetProperty("Year");

            var requiredAttribute = yearProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(1999)]
        [TestCase(2017)]
        public void Year_ShouldSetDataCorrectly(int testYear)
        {
            var advert = new Advert {Year = testYear};

            Assert.AreEqual(testYear, advert.Year);
        }

        [Test]
        public void Power_ShouldHaveRequiredAttribute()
        {
            var powerProp = typeof(Advert).GetProperty("Power");

            var requiredAttribute = powerProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(247)]
        [TestCase(1001)]
        public void Power_ShouldSetDataCorrectly(int testPower)
        {
            var advert = new Advert { Power = testPower };

            Assert.AreEqual(testPower, advert.Power);
        }

        [Test]
        public void DistanceCoverage_ShouldHaveRequiredAttribute()
        {
            var distanceCoverageProp = typeof(Advert).GetProperty("DistanceCoverage");

            var requiredAttribute = distanceCoverageProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(50000)]
        [TestCase(250000)]
        public void DistanceCoverage_ShouldSetDataCorrectly(int testDistanceCoverage)
        {
            var advert = new Advert { DistanceCoverage = testDistanceCoverage };

            Assert.AreEqual(testDistanceCoverage, advert.DistanceCoverage);
        }

        [Test]
        public void Description_ShouldHaveRequiredAttribute()
        {
            var descriptionProp = typeof(Advert).GetProperty("Description");

            var requiredAttribute = descriptionProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Description_ShouldHaveTheCorrectMinLength()
        {
            var descriptionProp = typeof(Advert).GetProperty("Description");

            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertDescriptionMinLength));
        }

        [Test]
        public void Description_ShouldHaveTheCorrectMaxLength()
        {
            var descriptionProp = typeof(Advert).GetProperty("Description");

            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertDescriptionMaxLength));
        }

        [TestCase("I Crashed My car Like 42 Times!!! Please Buy It!!!")]
        [TestCase("I Crashed My car Like 12312313 Times!!! Please Buy It!!!")]
        public void Description_ShouldSetDataCorrectly(string testDescription)
        {
            var advert = new Advert {Description = testDescription};

            Assert.AreEqual(testDescription, advert.Description);
        }

        [Test]
        public void Constructor_ShouldInitializePictureCollectionCorreclty()
        {
            var advert = new Advert();
            var pictures = advert.Pictures;

            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<Picture>>());
        }

        [Test]
        public void Constructor_ShouldHaveParametlessConstructor()
        {
            var advert = new Advert();

            Assert.IsInstanceOf<Advert>(advert);
        }
    }
}
