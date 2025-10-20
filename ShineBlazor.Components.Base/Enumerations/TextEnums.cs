namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// The alignment.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum Alignment
{
    /// <summary>
    /// Start.
    /// </summary>
    [StringValue("start")]
    Start,
    /// <summary>
    /// Center.
    /// </summary>
    [StringValue("center")]
    Center,
    /// <summary>
    /// End.
    /// </summary>
    [StringValue("end")]
    End
}

/// <summary>
/// The view port sizes.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum ViewportSize
{
    /// <summary>
    /// Small.
    /// </summary>
    [StringValue("sm")]
    SM,
    /// <summary>
    /// Medium.
    /// </summary>
    [StringValue("md")]
    MD,
    /// <summary>
    /// Large.
    /// </summary
    [StringValue("lg")]
    LG,
    /// <summary>
    /// Extra large.
    /// </summary
    [StringValue("xl")]
    XL,
    /// <summary>
    /// Extra extra large.
    /// </summary>
    [StringValue("xxl")]
    XXL
}


/// <summary>
/// The text wrap.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum TextWrap
{
    /// <summary>
    /// Wrap text.
    /// </summary>
    [StringValue("text-wrap")]
    Wrap,
    /// <summary>
    /// No wrap.
    /// </summary
    [StringValue("text-nowrap")]
    NoWrap
}

/// <summary>
/// The text transform.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum TextTransform
{
    /// <summary>
    /// Lowercase.
    /// </summary>
    [StringValue("text-lowercase")]
    Lowercase,
    /// <summary>
    /// Uppercase.
    /// </summary>
    [StringValue("text-uppercase")]
    Uppercase,
    /// <summary>
    /// Capitalize.
    /// </summary>
    [StringValue("text-capitalize")]
    Capitalize
}
