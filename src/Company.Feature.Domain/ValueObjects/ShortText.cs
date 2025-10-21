namespace Company.Feature.Domain.ValueObjects;

public readonly record struct ShortText
{
  private readonly string _value;
  public string Value => _value;

  public ShortText(string value)
  {    
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException("Text cannot be empty", nameof(value));
    if (value.Length > 256)
      throw new ArgumentException("Text cannot exceed 256 characters", nameof(value));
    if (ContainsDangerousCharacters(value))
      throw new ArgumentException("Text contains invalid characters", nameof(value));

    _value = value;
  }

  public override string ToString() => _value;

  // Conversion implicite pour faciliter l’usage
  public static implicit operator string(ShortText text) => text._value;
  public static implicit operator ShortText(string value) => new ShortText(value);
  
  private static bool ContainsDangerousCharacters(string value)
  {
    // Stop scripts HTML / JS or not printable characters
    return value.Any(c => c < 32 || c == '<' || c == '>' || c == '&');
  }
}
