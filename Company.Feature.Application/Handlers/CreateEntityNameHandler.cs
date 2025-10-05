using Company.Feature.Application.Repositories;

namespace Company.Feature.Application.Handlers;

public class CreateEntityNameHandler
{
  private readonly IEntityNameRepository _repository;

  public CreateEntityNameHandler(IEntityNameRepository repository)
  {
    _repository = repository ?? throw new ArgumentNullException(nameof(repository));
  }

  //public async Task<EntityNameDto> Handle(CreateEntityNameCommand command)
  //{
  //  // Orchestration
  //  var entityName = new EntityName(Id.New());

  //  await _repository.AddAsync(entityName); 
  //  return new EntityNameDto(entityName.Id.Value);
  //}
}
