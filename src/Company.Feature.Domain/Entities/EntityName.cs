// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

using Company.Feature.Domain.ValueObjects;

namespace Company.Feature.Domain.Entities;

public record EntityName
{
  public Id Id { get; init; } = new();

  public AuditInfo Audit { get; init; } = new();

  public ShortText Name { get; init; }
}
