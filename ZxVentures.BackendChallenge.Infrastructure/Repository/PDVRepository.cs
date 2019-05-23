using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Application.PDVS;
using ZxVentures.BackendChallenge.Infrastructure.Data;
using ZXVentures.BackendChallenge.Domain;

namespace ZxVentures.BackendChallenge.Infrastructure.Repository
{
    public class PDVRepository : BaseRepository<PDV>, IPDVRepository
    {
        public PDVRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
        public async Task<IEnumerable<PDV>> Search(double lng, double lat)
        {
            var point = GeoJson.Point(GeoJson.Geographic(lng, lat));

            var filter = Builders<PDV>.Filter.GeoIntersects(p => p.CoverageArea, point);

            using (var cursor = await GetCollection().FindAsync(filter))
            {
                return await cursor.ToListAsync();
            }
        }
    }
}
