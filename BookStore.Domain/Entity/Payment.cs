using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Payment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("payment_date")]
    public DateTime PaymentDate { get; set; }

    [BsonElement("amount")]
    public double Amount { get; set; }

    [BsonElement("payment_method")]
    public string? PaymentMethod { get; set; }

    [BsonElement("transaction_id")]
    public string? TransactionId { get; set; }

    [BsonElement("customer_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CustomerId { get; set; }
}
