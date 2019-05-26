using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.GeoJSON;
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

            var coverageArea = GeoJSONFactory.NewMultiPolygon(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } });
            var address = GeoJSONFactory.NewPoint(0, 0);

            var pdv = new PDV("1", legalPeople, coverageArea, address);

            Assert.AreSame("1", pdv.Code);
        }

        [TestMethod]
        public void Constructor_CompanySetter()
        {
            var legalPeople = new LegalPeople("foo", "bar", "xyz", new NaturalPeople("xyz"));

            var coverageArea = GeoJSONFactory.NewMultiPolygon(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } });
            var address = GeoJSONFactory.NewPoint(0, 0);

            var pdv = new PDV("1", legalPeople, coverageArea, address);

            Assert.AreSame(legalPeople, pdv.Company);
        }
    }
}
