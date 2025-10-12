using NetArchTest.Rules;

namespace Company.Feature.Architecture.Tests;

public class ArchitectureTests
{
  [Fact]
  public void Domain_Should_Not_Depend_On_Application()
  {
    var result = Types
        .InAssembly(typeof(Company.Feature.Domain.Entities.EntityName).Assembly)
        .ShouldNot()
        .HaveDependencyOn("Company.Feature.Application")
        .GetResult();

    Assert.True(result.IsSuccessful);
  }
}
