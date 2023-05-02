//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Bson;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookStore.Domain.Entity
//{
//    [BsonIgnoreExtraElements]
//    public class User
//    {
//        [BsonId]
//        [BsonElement("_id")]
//        [BsonRepresentation(BsonType.ObjectId)]
//        [JsonProperty(PropertyName = "_id")]
//        public string? Id { get; set; }

//        [JsonProperty(PropertyName = "name")]
//        [BsonElement("name")]
//        public string? Name { get; set; }

//        [JsonProperty(PropertyName = "address")]
//        [BsonElement("address")]
//        public Address? Address { get; set; }

//        [JsonProperty(PropertyName = "emailAddress")]
//        [BsonElement("emailAddress")]
//        public string? EmailAddress { get; set; }

//        [JsonProperty(PropertyName = "phoneNumber")]
//        [BsonElement("phoneNumber")]
//        public double? PhoneNumber { get; set; }
//    }
//}
