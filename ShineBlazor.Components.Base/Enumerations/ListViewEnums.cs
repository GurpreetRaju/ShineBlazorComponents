namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// The list view size.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("list-view-default")]
internal enum ListViewSize
{
    /// <summary>
    /// Small.
    /// </summary>
    [StringValue("list-view-sm")]
    Sm,
    /// <summary>
    /// Large.
    /// </summary>
    [StringValue("list-view-lg")]
    Lg,
    /// <summary>
    /// Extra Large.
    /// </summary>
    [StringValue("list-view-xl")]
    Xl
}
