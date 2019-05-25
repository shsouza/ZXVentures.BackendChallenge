using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Application.PDVS;
using ZxVentures.BackendChallenge.Infrastructure.Data;
using ZxVentures.BackendChallenge.Infrastructure.Repository;
using ZXVentures.BackendChallenge.Application.PDVS;
using ZXVentures.BackendChallenge.Domain.GeoJSON;

namespace ZXVentures.BackendChallenge.ApplicationTests
{
    [TestClass]
    public class PDVServiceTest
    {
        private readonly PDVService pdvService;

        public PDVServiceTest()
        {
            var databaseContext = new DatabaseContext();

            var pdvRepository = new PDVRepository(databaseContext);

            pdvService = new PDVService(pdvRepository);
        }

        [TestMethod]
        public async Task Create_Get()
        {
            var document = Guid.NewGuid().ToString();
            var tradingName = Guid.NewGuid().ToString();
            var owner = Guid.NewGuid().ToString();

            var newPdv = new NewPDV
            {
                Code = "1",
                TradingName = tradingName,
                Owner = owner,
                Document = document,
                CoverageArea = GeoJSONFactory.NewMultiPolygon(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }),
                Address = GeoJSONFactory.NewPoint(0, 0)
            };

            var id = await pdvService.Create(newPdv);

            var created = await pdvService.Get(id);

            Assert.AreEqual(newPdv.Code, created.Code);
            Assert.AreEqual(newPdv.TradingName, created.Company.TradingName);
            Assert.AreEqual(newPdv.Document, created.Company.Document);
            Assert.AreEqual(newPdv.Owner, created.Company.Owner.Name);
            Assert.IsNotNull(created.CoverageArea);
            Assert.IsNotNull(created.Address);
        }

        [TestMethod]
        public async Task Create_Search()
        {
            var document = Guid.NewGuid().ToString();
            var tradingName = Guid.NewGuid().ToString();
            var owner = Guid.NewGuid().ToString();

            var newPdv = new NewPDV
            {
                Code = "1",
                TradingName = tradingName,
                Owner = owner,
                Document = document,
                CoverageArea = GeoJSONFactory.NewMultiPolygon(new double[,] {
                    {-46.944580078125, -23.51362636346272 },
                    {-46.8841552734375, -23.74009762440226 },
                    {-46.4996337890625, -23.810475327766568 },
                    {-46.219482421875, -23.55391651832161 },
                    {-46.59301757812499, -23.301901124188877 },
                    {-46.944580078125,  -23.51362636346272 }
                }),
                Address = GeoJSONFactory.NewPoint(0, 0)
            };

            var id = await pdvService.Create(newPdv);

            var list = await pdvService.Search(-46.65893554687499, -23.54384513650583);

            Assert.IsTrue(list.Any(p => p.Company.TradingName == newPdv.TradingName));
        }
    }
}
