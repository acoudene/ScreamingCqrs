using Company.Feature.UseCases.Dtos;
using Company.Feature.UseCases.Repositories;

namespace Company.Feature.UseCases;

public record CreateEntityNameInput(EntityNameDto Data);

public class CreateEntityNameCommand
{
  private readonly IEntityNameRepository _repository;

  public CreateEntityNameCommand(IEntityNameRepository repository)
  {
    ArgumentNullException.ThrowIfNull(repository);

    _repository = repository;
  }

  public async Task ExecuteAsync(CreateEntityNameInput input, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(input);

    var entity = input.Data.ToDomain();
    await _repository.AddAsync(entity);    
  }
}

