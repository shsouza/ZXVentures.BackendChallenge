using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZXVentures.BackendChallenge.DomainTests
{
    [TestClass]
    public class PDVTest
    {
        [TestMethod]
        public void Constructor_CompanyValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new PDV("0", null, null, null));
        }

        [TestMethod]
        public void Constructor_CodeSetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            var pdv = new PDV("1", legalPeople, null, null);

            Assert.AreSame("1", pdv.Code);
        }

        [TestMethod]
        public void Constructor_CompanySetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            var pdv = new PDV("1", legalPeople, null, null);

            Assert.AreSame(legalPeople, pdv.Company);
        }
    }
}
