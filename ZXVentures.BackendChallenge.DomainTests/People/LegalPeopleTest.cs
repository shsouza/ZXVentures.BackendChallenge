using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZXVentures.BackendChallenge.DomainTests.People
{
    [TestClass]
    public class LegalPeopleTest
    {
        [TestMethod]
        public void Constructor_TradingNameValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new LegalPeople(null, "foo", "bar", new NaturalPeople("xyz")));
        }

        [TestMethod]
        public void Constructor_NameValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new LegalPeople("foo", null, "bar", new NaturalPeople("xyz")));
        }

        [TestMethod]
        public void Constructor_DocumentValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new LegalPeople("foo", "bar", null, new NaturalPeople("xyz")));
        }

        [TestMethod]
        public void Constructor_OwnerValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new LegalPeople("foo", "bar", "xyz", null));
        }

        [TestMethod]
        public void Constructor_TradingNameSetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            Assert.AreEqual("foo", legalPeople.TradingName);
        }

        [TestMethod]
        public void Constructor_NameSetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            Assert.AreEqual("bar", legalPeople.Name);
        }

        [TestMethod]
        public void Constructor_DocumentSetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            Assert.AreEqual("xyz", legalPeople.Document);
        }

        [TestMethod]
        public void Constructor_OwnerSetter()
        {
            var owner = new NaturalPeople("xyz");

            var legalPeople = new LegalPeople("foo", "bar", "xyz", owner);

            Assert.AreSame(owner, owner);
        }
    }
}
