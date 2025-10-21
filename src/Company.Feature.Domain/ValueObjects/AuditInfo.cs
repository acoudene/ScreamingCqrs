namespace Company.Feature.Domain.ValueObjects;

public readonly record struct AuditInfo(DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt)
{
  public AuditInfo() : this(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
  {
  }

  public AuditInfo MarkUpdated()
      => this with { UpdatedAt = DateTimeOffset.UtcNow };
}


