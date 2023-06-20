using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MTBS.MovieCatalogAPI.Helpers;
using System.Text.Json.Serialization;

namespace MTBS.MovieCatalogAPI.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string MovieLength { get; set; }
        public string ReleaseYear { get; set; }
        [JsonConverter(typeof(ByteArrayConverter))]
        public byte[] ThumbnailPic { get; set; } = Array.Empty<byte>();
        public List<List<string>> StartTimes { get; set; }
    }
}
