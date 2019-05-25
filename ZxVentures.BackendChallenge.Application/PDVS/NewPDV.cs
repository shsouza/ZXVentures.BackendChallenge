using MongoDB.Driver.GeoJsonObjectModel;

namespace ZXVentures.BackendChallenge.Application.PDVS
{
    public class NewPDV
    {
        public string Code { get; set; }

        public string TradingName { get; set; }

        public string Owner { get; set; }

        public string Document { get; set; }

        public GeoJsonMultiPolygon<GeoJson2DCoordinates> CoverageArea { get; set; }

        public GeoJsonPoint<GeoJson2DCoordinates> Address { get; set; }
    }
}
