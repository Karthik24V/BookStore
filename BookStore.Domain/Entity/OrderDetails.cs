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
    public class OrderDetails
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        [BsonElement("bookId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BookId { get; set; }

        [JsonProperty(PropertyName = "price")]
        [BsonElement("price")]
        public double? Price { get; set; }
        
        [JsonProperty(PropertyName = "quantity")]
        [BsonElement("quantity")]
        public int? Quantity { get; set; }

    }
}
