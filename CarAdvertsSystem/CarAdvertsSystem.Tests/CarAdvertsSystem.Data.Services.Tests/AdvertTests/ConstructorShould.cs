﻿using System;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services;

using Moq;
using NUnit.Framework;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.Data.Services.Tests.AdvertTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateAdvertServices_IfParamsAreValid()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var advertService = new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.That(advertService, Is.InstanceOf<AdvertServices>());
        }

        [Test]
        public void Constructor_Should_ThrowNullReferenceException_IfPassedRepositoryIsNull()
        {
            Mock<IRepository<Advert>> mockedRepository = null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<NullReferenceException>(
                () => new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void Constuctor_Should_ThrowNullReferenceException_IfPassedUnitOfWorkIsNull()
        {
            var mockedRepository = new Mock<IRepository<Advert>>();
            Mock<IUnitOfWork> mockedUnitOfWork = null;

            Assert.Throws<NullReferenceException>(
                () => new AdvertServices(mockedRepository.Object, mockedUnitOfWork.Object));
        }
    }
}
