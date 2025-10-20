namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// Button Size.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum BtnSize
{
    /// <summary>
    /// Small.
    /// </summary>
    [StringValue("btn-sm")]
    Sm,
    /// <summary>
    /// Large.
    /// </summary>
    [StringValue("btn-lg")]
    Lg,
    /// <summary>
    /// Extra large.
    /// </summary>
    [StringValue("btn-xl")]
    Xl
}

/// <summary>
/// The button variant.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("btn")]
internal enum BtnVariant
{
    /// <summary>
    /// Link.
    /// </summary>
    [StringValue("btn-link")]
    Link,
    /// <summary>
    /// Text.
    /// </summary>
    [StringValue("btn-text")]
    Text,
    /// <summary>
    /// Outline.
    /// </summary>
    [StringValue("btn-outline")]
    Outline
}

/// <summary>
/// Button Type.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum BtnType
{
    /// <summary>
    /// Button.
    /// </summary>
    [StringValue("button")]
    Button,
    /// <summary>
    /// Submit.
    /// </summary>
    [StringValue("submit")]
    Submit,
    /// <summary>
    /// Reset.
    /// </summary>
    [StringValue("reset")]
    Reset
}
