using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZXVentures.BackendChallenge.DomainTests.People
{
    [TestClass]
    public class NaturalPeopleTest
    {
        [TestMethod]
        public void Constructor_NameValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new NaturalPeople(null));
        }

        [TestMethod]
        public void Constructor_NameSetter()
        {
            var people = new NaturalPeople("foobar");

            Assert.AreEqual("foobar", people.Name);
        }
    }
}
