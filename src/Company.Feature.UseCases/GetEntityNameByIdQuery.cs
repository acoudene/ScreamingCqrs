using Company.Feature.Domain.ValueObjects;
using Company.Feature.UseCases.Dtos;
using Company.Feature.UseCases.Repositories;

namespace Company.Feature.UseCases;

public record GetEntityNameByIdInput(Id EntityId);

public record GetEntityNameByIdOutput(EntityNameDto? Item);

public class GetEntityNameByIdQuery
{
  private readonly IEntityNameRepository _repository;

  public GetEntityNameByIdQuery(IEntityNameRepository repository)
  {
    _repository = repository;
  }

  public async Task<GetEntityNameByIdOutput> ExecuteAsync(GetEntityNameByIdInput input)
  {
    var entity = await _repository.GetByIdAsync(input.EntityId);
    if (entity is null) 
      return new GetEntityNameByIdOutput(null);

    var dto = new EntityNameDto(entity.Id, entity.Name);
    return new GetEntityNameByIdOutput(dto);
  }
}