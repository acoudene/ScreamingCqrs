using Company.Feature.Domain.Entities;

namespace Company.Feature.UseCases.Repositories;

public interface IEntityNameRepository
{
  Task<EntityName?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

  Task<List<EntityName>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
  Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default);

  Task<List<EntityName>> FindByName(string name, int page, int pageSize, CancellationToken cancellationToken = default);
  Task<int> GetTotalCountByNameAsync(string name, CancellationToken cancellationToken = default);

  Task AddAsync(EntityName entity, CancellationToken cancellationToken = default);
  Task UpdateAsync(EntityName entity, CancellationToken cancellationToken = default);
  Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
