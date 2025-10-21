using Company.Feature.Domain.Entities;

namespace Company.Feature.UseCases.Dtos;

public static class DtosExtensions
{
  public static EntityName ToDomain(this EntityNameDto dto)
    => new EntityName()
    {
      Id = dto.Id
    };

  public static EntityNameDto ToDto(this EntityName entity)
    => new EntityNameDto(entity.Id, entity.Name);
}
