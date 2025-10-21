using Company.Feature.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Company.Feature.Api.Endpoints;

public static class EndpointsExtensions
{
  private const string BasePath = "/api/entitynames";

  public static void MapEntityNameEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapGet(BasePath, async (GetAllEntityNamesQuery query) =>
    {
      // TODO
      var input = new GetAllEntityNamesInput(Page: 0, PageSize: 1000);

      var result = await query.ExecuteAsync(input);
      return Results.Ok(result);
    })
    .WithName("GetAllEntityNames");
  }
}
