using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace BookStore.Domain.Entity
{
    [BsonIgnoreExtraElements]
    public class Books
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        [BsonElement("title")]
        public string? Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        [BsonElement("author")]
        public string? Author { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        [BsonElement("publisher")]
        public string? Publisher { get; set; }

        [JsonProperty(PropertyName = "price")]
        [BsonElement("price")]
        public double? Price { get; set; }

        [JsonProperty(PropertyName = "publicationYear")]
        [BsonElement("publicationYear")]
        public int PublicationYear { get; set; }

        [JsonProperty(PropertyName = "description")]
        [BsonElement("description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        [BsonElement("isbn")]
        public string? ISBN { get; set; }

        [JsonProperty(PropertyName = "genere")]
        [BsonElement("genere")]
        public List<string>? Genere { get; set; }
        
        [JsonProperty(PropertyName = "quantity")]
        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
