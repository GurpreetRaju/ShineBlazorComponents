namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// The nav menu style.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("")]
internal enum NavVariant
{
    /// <summary>
    /// Pills style.
    /// </summary>
    [StringValue("nav-pills")]
    Pills,
    
    /// <summary>
    /// Underline style.
    /// </summary>
    [StringValue("nav-underline")]
    Underline
}
