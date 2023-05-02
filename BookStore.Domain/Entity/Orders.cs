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
    public class Orders
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "orderDate")]
        [BsonElement("orderDate")]
        public DateTime? OrderDate { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CustomerId { get; set; }

        [JsonProperty(PropertyName = "shippingAddress")]
        [BsonElement("shippingAddress")]
        public Address? ShippingAddress { get; set; }

        [JsonProperty(PropertyName = "paymentInfo")]
        [BsonElement("paymentInfo")]
        public string? PaymentInfo { get; set; }

        [JsonProperty(PropertyName = "booksOrdered")]
        [BsonElement("booksOrdered")]
        public List<Books>? BooksOrdered { get; set; }
    }
}

