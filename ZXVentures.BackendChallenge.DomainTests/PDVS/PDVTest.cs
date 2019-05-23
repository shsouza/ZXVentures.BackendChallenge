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
            Assert.ThrowsException<ArgumentException>(() => new PDV(null, new { }, new { }));
        }

        [TestMethod]
        public void Constructor_Setter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            var pdv = new PDV(legalPeople, new { }, new { });

            Assert.AreSame(legalPeople, pdv.Company);
        }
    }
}
