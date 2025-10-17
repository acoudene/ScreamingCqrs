using System.Reflection;

namespace Company.Feature.Architecture.Tests;

public class ArchitectureTests
{
  private const string assemblyDomain = "Company.Feature.Domain";
  private const string assemblyUseCases = "Company.Feature.UseCases";

  private static List<string> GetInvalidDependencies(string assemblyName, string[] allowedPrefixes)
  {
    var assembly = Assembly.Load(assemblyName);

    var referencedAssemblies = assembly.GetReferencedAssemblies();
    var invalidRefs = referencedAssemblies
      .Where(a => !allowedPrefixes.Any(prefix => a.Name is not null && a.Name.StartsWith(prefix)))
      .Select(a => (a.Name is not null) ? a.Name : string.Empty)
      .ToList();
    
    return invalidRefs;
  }

  [Fact]
  public void Domain_Should_Not_Depend_On_Any_Dependencies_Except_DotNet_Framework()
  {
    /// Arrange
    string selectedAssemblyName = assemblyDomain;
    string[] allowedPrefixes = ["System", "Microsoft", "netstandard"];

    /// Act    
    List<string> invalidRefs = GetInvalidDependencies(selectedAssemblyName, allowedPrefixes);

    /// Assert
    Assert.True(
        invalidRefs.Count == 0,
        $"{selectedAssemblyName} has not allowed dependencies: {string.Join(", ", invalidRefs)}"
    );
  }

  [Fact]
  public void UseCases_Should_Not_Depend_On_Any_Dependencies_Except_DotNet_Framework_And_Domain()
  {
    /// Arrange
    string selectedAssemblyName = assemblyUseCases;
    string[] allowedPrefixes = ["System", "Microsoft", "netstandard", assemblyDomain];

    /// Act    
    List<string> invalidRefs = GetInvalidDependencies(selectedAssemblyName, allowedPrefixes);

    /// Assert
    Assert.True(
        invalidRefs.Count == 0,
        $"{selectedAssemblyName} has not allowed dependencies: {string.Join(", ", invalidRefs)}"
    );
  }
}
