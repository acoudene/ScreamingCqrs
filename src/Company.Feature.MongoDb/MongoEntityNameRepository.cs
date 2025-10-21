using Company.Feature.Domain.Entities;
using Company.Feature.MongoDb.Entities;
using Company.Feature.UseCases.Repositories;
using MongoDB.Driver;

namespace Company.Feature.MongoDb;

public class MongoEntityNameRepository : IEntityNameRepository
{
  private const string CollectionName = "entityNames";
  private readonly IMongoCollection<EntityNameDocument> _collection;

  public MongoEntityNameRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<EntityNameDocument>(CollectionName);
  }

  public async Task<EntityName?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var filter = Builders<EntityNameDocument>.Filter.Eq(x => x.Id, id);
    var doc = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    return doc?.ToDomain();
  }

  public async Task<List<EntityName>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default)
  {
    var docs = await _collection
        .Find(FilterDefinition<EntityNameDocument>.Empty)
        .Skip(page * pageSize)
        .Limit(pageSize)
        .ToListAsync(cancellationToken);

    return docs.Select(d => d.ToDomain()).ToList();
  }

  public async Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default)
  {
    var count = await _collection.CountDocumentsAsync(FilterDefinition<EntityNameDocument>.Empty, cancellationToken: cancellationToken);
    return (int)count;
  }

  public async Task<List<EntityName>> FindByName(string name, int page, int pageSize, CancellationToken cancellationToken = default)
  {
    var filter = Builders<EntityNameDocument>.Filter.Regex(x => x.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));

    var docs = await _collection
        .Find(filter)
        .Skip(page * pageSize)
        .Limit(pageSize)
        .ToListAsync(cancellationToken);

    return docs.Select(d => d.ToDomain()).ToList();
  }

  public async Task<int> GetTotalCountByNameAsync(string name, CancellationToken cancellationToken = default)
  {
    var filter = Builders<EntityNameDocument>.Filter.Regex(x => x.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));
    var count = await _collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);
    return (int)count;
  }

  public async Task AddAsync(EntityName entity, CancellationToken cancellationToken = default)
  {
    var doc = entity.ToDocument();
    await _collection.InsertOneAsync(doc, cancellationToken: cancellationToken);
  }

  public async Task UpdateAsync(EntityName entity, CancellationToken cancellationToken = default)
  {
    var doc = entity.ToDocument();
    var filter = Builders<EntityNameDocument>.Filter.Eq(x => x.Id, entity.Id.Value);
    await _collection.ReplaceOneAsync(filter, doc, cancellationToken: cancellationToken);
  }

  public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var filter = Builders<EntityNameDocument>.Filter.Eq(x => x.Id, id);
    await _collection.DeleteOneAsync(filter, cancellationToken);
  }
}
