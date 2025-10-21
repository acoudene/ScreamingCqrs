using Company.Feature.Domain.Entities;
using Company.Feature.Domain.ValueObjects;

namespace Company.Feature.MongoDb.Entities;

public static class DocumentsExtensions
{
  public static EntityNameDocument ToDocument(this EntityName entity)
        => new()
        {
          Id = entity.Id.Value,
          Name = entity.Name.Value,
          CreatedAt = entity.Audit.CreatedAt,
          UpdatedAt = entity.Audit.UpdatedAt
        };

  public static EntityName ToDomain(this EntityNameDocument document)
      => new()
      {
        Id = new Id(document.Id),
        Name = new ShortText(document.Name)        
      };
}
