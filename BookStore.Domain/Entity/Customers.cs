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
    public class Customers
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        [BsonElement("address")]
        public Address? Address { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        [BsonElement("emailAddress")]
        public string? EmailAddress { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        [BsonElement("phoneNumber")]
        public double? PhoneNumber { get; set; }
    }

    public class Address
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "street")]
        [BsonElement("street")]
        public string? Street { get; set; }
        [JsonProperty(PropertyName = "city")]
        [BsonElement("city")]
        public string? City { get; set; }
        [JsonProperty(PropertyName = "state")]
        [BsonElement("state")]
        public string? State { get; set; }
        [JsonProperty(PropertyName = "country")]
        [BsonElement("country")]
        public string? Country { get; set; }
        [JsonProperty(PropertyName = "pincode")]
        [BsonElement("pincode")]
        public string? Pincode { get; set; }

    }
}

