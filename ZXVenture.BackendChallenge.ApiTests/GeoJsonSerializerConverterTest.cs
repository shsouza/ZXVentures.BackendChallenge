using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.GeoJsonObjectModel;
using ZXVenture.BackendChallenge.Api;

namespace ZXVenture.BackendChallenge.ApiTests
{
    [TestClass]
    public class GeoJsonSerializerConverterTest
    {
        [TestMethod]
        public void CanConvert()
        {
            var converter = new GeoJsonSerializerConverter();

            var result = converter.CanConvert(typeof(GeoJsonPoint<GeoJson2DCoordinates>));

            Assert.AreEqual(true, result);
        }
    }
}
