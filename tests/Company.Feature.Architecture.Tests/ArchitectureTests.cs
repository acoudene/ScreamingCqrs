using System.Reflection;

namespace Company.Feature.Architecture.Tests;

public class ArchitectureTests
{  
  [Fact]
  public void Domain_Should_Not_Depend_On_Any_Dependencies_Except_DotNet_Framework()
  {
    /// Arrange
    string[] AllowedPrefixes = [ "System", "Microsoft", "netstandard" ];    
    var assembly = Assembly.Load("Company.Feature.Domain");
    
    /// Act
    var referencedAssemblies = assembly.GetReferencedAssemblies();
    var invalidRefs = referencedAssemblies
        .Where(a => !AllowedPrefixes.Any(prefix => string.IsNullOrWhiteSpace(a.Name) || a.Name.StartsWith(prefix)))
        .Select(a => a.Name)
        .ToList();

    /// Assert
    Assert.True(
        invalidRefs.Count == 0,
        $"{assembly.GetName().Name} has not allowed dependencies: {string.Join(", ", invalidRefs)}"
    );
  }
}
