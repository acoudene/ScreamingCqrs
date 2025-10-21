using Company.Feature.UseCases.Dtos;
using Company.Feature.UseCases.Repositories;

namespace Company.Feature.UseCases;

public record GetAllEntityNamesInput(int Page, int PageSize);

public record GetAllEntityNamesOutput(IEnumerable<EntityNameDto> Items, int TotalCount);

public class GetAllEntityNamesQuery
{
  private readonly IEntityNameRepository _repository;

  public GetAllEntityNamesQuery(IEntityNameRepository repository)
  {
    ArgumentNullException.ThrowIfNull(repository);
    _repository = repository;
  }

  public async Task<GetAllEntityNamesOutput> ExecuteAsync(GetAllEntityNamesInput input, CancellationToken cancellationToken = default)
  {
    var entities = await _repository.GetAllAsync(input.Page, input.PageSize, cancellationToken);
    var dtos = entities.Select(e => new EntityNameDto(e.Id, e.Name));
    return new GetAllEntityNamesOutput(dtos, dtos.Count());
  }
}
