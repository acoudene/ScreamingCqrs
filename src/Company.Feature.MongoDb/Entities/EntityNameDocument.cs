using MongoDB.Bson.Serialization.Attributes;

namespace Company.Feature.MongoDb.Entities;

public class EntityNameDocument
{
  [BsonId]
  public Guid Id { get; set; }

  [BsonElement("name")]
  public string Name { get; set; } = string.Empty;

  [BsonElement("createdAt")]
  public DateTimeOffset CreatedAt { get; set; }

  [BsonElement("updatedAt")]
  public DateTimeOffset UpdatedAt { get; set; }
}
