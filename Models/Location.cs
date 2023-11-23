using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Capstone.Models
{
    [BsonIgnoreExtraElements]
    public class Location
    {
        internal readonly object location;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("location")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("latitude")]
        public double latitude { get; set; } 

        [BsonElement("longitude")]
        public double longitude { get; set; } 
    }
}
