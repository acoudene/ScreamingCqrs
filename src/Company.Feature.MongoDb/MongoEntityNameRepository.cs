using Company.Feature.Domain.Entities;
using Company.Feature.UseCases.Repositories;
using MongoDB.Driver;

namespace Company.Feature.MongoDb;

public class MongoEntityNameRepository : IEntityNameRepository
{
  private readonly IMongoCollection<EntityName> _collection;

  public MongoEntityNameRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<EntityName>("EntityNames");
  }

  public async Task<IEnumerable<EntityName>> GetAllAsync(CancellationToken ct = default)
  {
    return await _collection.Find(FilterDefinition<EntityName>.Empty).ToListAsync(ct);
  }
}
