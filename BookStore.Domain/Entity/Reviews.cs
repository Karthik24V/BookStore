using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entity
{
    public class Reviews
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "customerId")]
        public string? CustomerId { get; set; }
        
        [BsonElement("bookId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "bookId")]
        public string? BookId { get; set; }
        
        [BsonElement("reviewText")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "reviewText")]
        public string? ReviewText { get; set; }
        
        [BsonElement("reviewDate")]
        [JsonProperty(PropertyName = "reviewDate")]
        public DateTime? ReviewDate { get; set; }
    }
}
