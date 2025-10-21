namespace Company.Feature.Domain.ValueObjects;

public readonly record struct Id(Guid Value)
{
  public Id() : this(Guid.NewGuid())
  {
  }  

  public override string ToString() => Value.ToString();

  public static implicit operator Guid(Id id) => id.Value;
  public static implicit operator Id(Guid value) => new(value);
}
