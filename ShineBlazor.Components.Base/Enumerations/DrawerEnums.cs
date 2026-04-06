namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// The drawer position.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("left")]
public enum DrawerPosition
{
    /// <summary>
    /// Left.
    /// </summary>
    [StringValue("left")]
    Left,
    /// <summary>
    /// Right.
    /// </summary>
    [StringValue("right")]
    Right
}

/// <summary>
/// The position of trigger in the drawer.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("none")]
public enum TriggerPosition
{
    /// <summary>
    /// Hide trigger.
    /// </summary>
    [StringValue("none")]
    None,
    /// <summary>
    /// Top.
    /// </summary>
    [StringValue("top")]
    Top,
    /// <summary>
    /// Bottom.
    /// </summary>
    [StringValue("bottom")]
    Bottom
}
