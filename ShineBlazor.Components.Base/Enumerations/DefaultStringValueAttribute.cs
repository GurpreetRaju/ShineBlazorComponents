namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// String value generator.
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class DefaultStringValueAttribute : Attribute
{
    /// <summary>
    /// The string value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value"></param>
    public DefaultStringValueAttribute(string value) => Value = value;
}
