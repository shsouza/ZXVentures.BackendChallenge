using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Infrastructure.Repository;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZxVentures.BackendChallenge.Infrastructure.Tests
{
    [TestClass]
    public class PDVRepositoryTest
    {
        [TestMethod]
        public async Task Add()
        {
            var repository = new PDVRepository(new Data.DatabaseContext());

            var coverageArea = new GeoJsonMultiPolygon<GeoJson2DCoordinates>
            (
                new GeoJsonMultiPolygonCoordinates<GeoJson2DCoordinates>
                (
                    new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>[]
                    {
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
                        (
                            new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                            (
                                new GeoJson2DCoordinates[]
                                {
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0)
                                }
                            )
                        )
                    }
                )
            );

            var adrress = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(0, 0));

            var pdv = new PDV("1", new LegalPeople("foo", "bar", "123", new NaturalPeople("xyz")), coverageArea, adrress);

            await repository.Add(pdv);
        }

        [TestMethod]
        public async Task FirstOrDefault()
        {
            var repository = new PDVRepository(new Data.DatabaseContext());

            var coverageArea = new GeoJsonMultiPolygon<GeoJson2DCoordinates>
            (
                new GeoJsonMultiPolygonCoordinates<GeoJson2DCoordinates>
                (
                    new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>[]
                    {
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
                        (
                            new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                            (
                                new GeoJson2DCoordinates[]
                                {
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0)
                                }
                            )
                        )
                    }
                )
            );

            var adrress = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(0, 0));

            var pdv = new PDV("1",new LegalPeople("foo", "bar", "123", new NaturalPeople("xyz")), coverageArea, adrress);

            await repository.Add(pdv);

            var ret = await repository.FirstOrDefault(p => p.Id == pdv.Id);

            Assert.AreEqual(pdv.Id, ret.Id);

        }

        [TestMethod]
        public async Task Remove()
        {
            var repository = new PDVRepository(new Data.DatabaseContext());

            var coverageArea = new GeoJsonMultiPolygon<GeoJson2DCoordinates>
            (
                new GeoJsonMultiPolygonCoordinates<GeoJson2DCoordinates>
                (
                    new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>[]
                    {
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
                        (
                            new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                            (
                                new GeoJson2DCoordinates[]
                                {
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0),
                                    new GeoJson2DCoordinates(0, 0)
                                }
                            )
                        )
                    }
                )
            );

            var adrress = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(0, 0));

            var pdv = new PDV("1", new LegalPeople("foo", "bar", "123", new NaturalPeople("xyz")), coverageArea, adrress);

            await repository.Add(pdv);

            await repository.Remove(p => p.Id == pdv.Id);

            var ret = await repository.FirstOrDefault(p => p.Id == pdv.Id);

            Assert.IsNull(ret);
        }

        [TestMethod]
        public async Task Search_Intersects()
        {
            var repository = new PDVRepository(new Data.DatabaseContext());

            var coverageArea = new GeoJsonMultiPolygon<GeoJson2DCoordinates>
                (
                    new GeoJsonMultiPolygonCoordinates<GeoJson2DCoordinates>
                    (
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>[]
                        {
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
                        (
                            new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                            (
                                new GeoJson2DCoordinates[]
                                {
                                    new GeoJson2DCoordinates(-46.944580078125, -23.51362636346272),
                                    new GeoJson2DCoordinates(-46.8841552734375, -23.74009762440226),
                                    new GeoJson2DCoordinates(-46.4996337890625, -23.810475327766568),
                                    new GeoJson2DCoordinates(-46.219482421875, -23.55391651832161),
                                    new GeoJson2DCoordinates(-46.59301757812499, -23.301901124188877),
                                    new GeoJson2DCoordinates(-46.944580078125,  -23.51362636346272)
                                }
                            )
                        )
                        }
                    )
                );

            var adrress = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(0, 0));

            var pdv = new PDV("1", new LegalPeople("foo", "bar", "123", new NaturalPeople("xyz")), coverageArea, adrress);

            await repository.Add(pdv);

            var ret = await repository.Search(-46.65893554687499, -23.54384513650583);

            Assert.IsNotNull(ret.Where(p => p.Id == pdv.Id));
        }

        [TestMethod]
        public async Task Search_NotIntersects()
        {
            var repository = new PDVRepository(new Data.DatabaseContext());

            var coverageArea = new GeoJsonMultiPolygon<GeoJson2DCoordinates>
                (
                    new GeoJsonMultiPolygonCoordinates<GeoJson2DCoordinates>
                    (
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>[]
                        {
                        new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
                        (
                            new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                            (
                                new GeoJson2DCoordinates[]
                                {
                                    new GeoJson2DCoordinates(-46.944580078125, -23.51362636346272),
                                    new GeoJson2DCoordinates(-46.8841552734375, -23.74009762440226),
                                    new GeoJson2DCoordinates(-46.4996337890625, -23.810475327766568),
                                    new GeoJson2DCoordinates(-46.219482421875, -23.55391651832161),
                                    new GeoJson2DCoordinates(-46.59301757812499, -23.301901124188877),
                                    new GeoJson2DCoordinates(-46.944580078125,  -23.51362636346272)
                                }
                            )
                        )
                        }
                    )
                );

            var adrress = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(0, 0));

            var pdv = new PDV("1", new LegalPeople("foo", "bar", "123", new NaturalPeople("xyz")), coverageArea, adrress);

            await repository.Add(pdv);

            var ret = await repository.Search(-46.44470214843749, -23.96115620034201);

            Assert.IsNull(ret.FirstOrDefault(p => p.Id == pdv.Id));
        }
    }
}