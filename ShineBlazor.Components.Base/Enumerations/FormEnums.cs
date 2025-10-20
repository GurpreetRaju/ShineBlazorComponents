namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// The control Size.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("form-control-default")]
internal enum ControlSize
{
    /// <summary>
    /// Small.
    /// </summary>
    [StringValue("form-control-sm")]
    Sm,
    /// <summary>
    /// Large.
    /// </summary>
    [StringValue("form-control-lg")]
    Lg,
    /// <summary>
    /// Extra large.
    /// </summary>
    [StringValue("form-control-xl")]
    Xl
}

/// <summary>
/// The input type.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("text")]
internal enum InputType
{
    /// <summary>
    /// Text input.
    /// </summary>
    [StringValue("text")]
    Text,
    /// <summary>
    /// Color input.
    /// </summary>
    [StringValue("color")]
    Color,
    /// <summary>
    /// Checkbox.
    /// </summary>
    [StringValue("checkbox")]
    Checkbox,
    /// <summary>
    /// Date input.
    /// </summary>
    [StringValue("date")]
    Date,
    /// <summary>
    /// Date and time.
    /// </summary>
    [StringValue("datetime-local")]
    DateTime,
    /// <summary>
    /// Email input.
    /// </summary>
    [StringValue("email")]
    Email,
    /// <summary>
    /// File input.
    /// </summary>
    [StringValue("file")]
    File,
    /// <summary>
    /// Month input.
    /// </summary>
    [StringValue("month")]
    Month,
    /// <summary>
    /// Number input.
    /// </summary>
    [StringValue("number")]
    Number,
    /// <summary>
    /// Password input.
    /// </summary>
    [StringValue("password")]
    Password,
    /// <summary>
    /// Textarea input.
    /// </summary>
    [StringValue("textarea")]
    TextArea,
    /// <summary>
    /// Time input.
    /// </summary>
    [StringValue("time")]
    Time
}

/// <summary>
/// Input variant.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum InputVariant
{
    /// <summary>
    /// Outlined.
    /// </summary>
    [StringValue("form-outlined")]
    Outlined,
    /// <summary>
    /// Floating label.
    /// </summary>
    [StringValue("form-floating")]
    Floating
}
