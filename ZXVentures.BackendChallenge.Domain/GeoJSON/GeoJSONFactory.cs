using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;

namespace ZXVentures.BackendChallenge.Domain.GeoJSON
{
    public class GeoJSONFactory
    {
        public static GeoJsonMultiPolygon<GeoJson2DCoordinates> NewMultiPolygon(double[,] points)
        {
            var cordinates = new List<GeoJson2DCoordinates>();

            for (int i = 0; i < points.GetLength(0); i++)
            {
                cordinates.Add(new GeoJson2DCoordinates(points[i, 0], points[i, 1]));
            }

            return GeoJson.MultiPolygon(new GeoJsonPolygonCoordinates<GeoJson2DCoordinates>
            (
                new GeoJsonLinearRingCoordinates<GeoJson2DCoordinates>
                (
                    cordinates
                )
            ));
        }

        public static GeoJsonPoint<GeoJson2DCoordinates> NewPoint(double x, double y)
        {

            return GeoJson.Point(GeoJson.Position(x, y));
        }
    }
}
