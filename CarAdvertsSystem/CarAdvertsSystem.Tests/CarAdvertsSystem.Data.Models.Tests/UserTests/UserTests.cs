using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Common.Constants;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldHaveParametlessConstructor()
        {
            var user = new User();

            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void Constructor_ShouldInitializeAdvertCollectionCorreclty()
        {
            var user = new User();
            var adverts = user.Adverts;

            Assert.That(adverts, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }

        [Test]
        public void FirstName_ShouldHaveTheCorrectMinLength()
        {
            var firstNameProp = typeof(User).GetProperty("FirstName");

            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserFirstNameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveTheCorrectMaxLength()
        {
            var firstNameProp = typeof(User).GetProperty("FirstName");

            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserFirstNameMaxLength));
        }

        [TestCase("Vasil")]
        [TestCase("Ivan")]
        public void FirstName_ShouldSetTitleDataCorrectly(string testFirstName)
        {
            var user = new User { FirstName = testFirstName };

            Assert.AreEqual(testFirstName, user.FirstName);
        }

        [Test]
        public void LastName_ShouldHaveTheCorrectMinLength()
        {
            var firstNameProp = typeof(User).GetProperty("LastName");

            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserLastNameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveTheCorrectMaxLength()
        {
            var firstNameProp = typeof(User).GetProperty("LastName");

            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserLastNameMaxLength));
        }

        [TestCase("Penev")]
        [TestCase("Angelov")]
        public void LastName_ShouldSetTitleDataCorrectly(string testLastName)
        {
            var user = new User { LastName = testLastName };

            Assert.AreEqual(testLastName, user.LastName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var user = new User { IsDeleted = testIsDeleted };

            Assert.AreEqual(testIsDeleted, user.IsDeleted);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void AdvertCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };

            var user = new User() { Adverts = set };

            Assert.AreEqual(user.Adverts.First().Id, testId);
        }
    }
}
