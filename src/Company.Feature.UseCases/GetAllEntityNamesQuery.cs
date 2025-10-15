using Company.Feature.Domain.Entities;
using Company.Feature.UseCases.Repositories;

namespace Company.Feature.UseCases;

public class GetAllEntityNamesQuery
{
  private readonly IEntityNameRepository _repository;

  public GetAllEntityNamesQuery(IEntityNameRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<EntityName>> ExecuteAsync(CancellationToken ct = default)
  {
    var entities = await _repository.GetAllAsync(ct);
    return entities;
  }
}
