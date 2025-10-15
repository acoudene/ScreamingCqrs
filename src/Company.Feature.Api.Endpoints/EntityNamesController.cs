using Company.Feature.Api.Contracts;
using Company.Feature.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Company.Feature.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class EntityNamesController : ControllerBase
{
  private readonly GetAllEntityNamesQuery _query;

  public EntityNamesController(GetAllEntityNamesQuery query)
  {
    _query = query;
  }

  [HttpGet]
  public async Task<IEnumerable<EntityNameDto>> GetAll(CancellationToken ct)
  {
    return (await _query.ExecuteAsync(ct))
      .Select(e => new EntityNameDto(e.Id));
  }
}

