using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ZXVentures.BackendChallenge.Api
{
    public class GeoJsonSerializerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GeoJsonPoint<GeoJson2DCoordinates>)
                || objectType == typeof(GeoJsonMultiPolygon<GeoJson2DCoordinates>);
        }
        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            
            return BsonSerializer.Deserialize(item.ToString(), objectType);
        }        

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var geometry = (GeoJsonGeometry<GeoJson2DCoordinates>)value;

            writer.WriteRawValue(geometry.ToJson());
        }
    }
}
