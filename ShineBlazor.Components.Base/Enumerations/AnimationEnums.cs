namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// Animation.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum Animation
{
    /// <summary>
    /// Animates horizontally.
    /// </summary>
    [StringValue("animate-horizontal")]
    Horizontal,
    /// <summary>
    /// Animates vertically.
    /// </summary>
    [StringValue("animate-vertical")]
    Vertical,
    /// <summary>
    /// Animates scaling.
    /// </summary>
    [StringValue("animate-scale")]
    Scale,
    /// <summary>
    /// Animates rotation.
    /// </summary>
    [StringValue("animate-rotate")]
    Rotate
}

/// <summary>
/// The Timing function for animation.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("ease")]
internal enum AnimationTimingFunction
{
    /// <summary>
    /// Ease-in.
    /// </summary>
    [StringValue("ease-in")]
    EaseIn,
    /// <summary>
    /// Ease-out.
    /// </summary>
    [StringValue("ease-out")]
    EaseOut,
    /// <summary>
    /// Ease-in-out.
    /// </summary>
    [StringValue("ease-in-out")]
    EaseInOut,
    /// <summary>
    /// Linear.
    /// </summary>
    [StringValue("linear")]
    Linear,
    /// <summary>
    /// Step-start.
    /// </summary>
    [StringValue("step-start")]
    StepStart,
    /// <summary>
    /// Step-end.
    /// </summary>
    [StringValue("step-end")]
    StepEnd
}
