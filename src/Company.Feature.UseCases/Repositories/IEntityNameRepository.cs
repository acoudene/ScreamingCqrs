using Company.Feature.Domain.Entities;

namespace Company.Feature.UseCases.Repositories;

public interface IEntityNameRepository
{
  Task<IEnumerable<EntityName>> GetAllAsync(CancellationToken ct = default);
}
