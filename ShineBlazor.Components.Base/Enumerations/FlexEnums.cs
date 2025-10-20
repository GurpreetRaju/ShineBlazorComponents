namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// Flex Align.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum FlexAlign
{
    /// <summary>
    /// Flex Items Start.
    /// </summary>
    [StringValue("align-items-start")]
    ItemsStart,
    /// <summary>
    /// Flex Items End.
    /// </summary>
    [StringValue("align-items-end")]
    ItemsEnd,
    /// <summary>
    /// Flex Items Center.
    /// </summary>
    [StringValue("align-items-center")]
    ItemsCenter,
    /// <summary>
    /// Flex Items Stretch.
    /// </summary>
    [StringValue("align-items-stretch")]
    ItemsStretch,
    /// <summary>
    /// Flex Items Baseline.
    /// </summary>
    [StringValue("align-items-baseline")]
    ItemsBaseline,
    /// <summary>
    /// Flex Content Start.
    /// </summary>
    [StringValue("align-content-start")]
    ContentStart,
    /// <summary>
    /// Flex Content End.
    /// </summary>
    [StringValue("align-content-end")]
    ContentEnd,
    /// <summary>
    /// Flex Content Start.
    /// </summary>
    [StringValue("align-content-center")]
    ContentCenter,
    /// <summary>
    /// Content Space Between.
    /// </summary>
    [StringValue("align-content-between")]
    ContentBetween,
    /// <summary>
    /// Content Space Around.
    /// </summary>
    [StringValue("align-content-around")]
    ContentAround,
    /// <summary>
    /// Content Space Evenly.
    /// </summary>
    [StringValue("align-content-evenly")]
    ContentEvenly
}

/// <summary>
/// Flex align self.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum FlexAlignSelf
{
    /// <summary>
    /// Flex Self Start.
    /// </summary>
    [StringValue("align-self-start")]
    Start,
    /// <summary>
    /// Flex Self End.
    /// </summary>
    [StringValue("align-self-end")]
    End,
    /// <summary>
    /// Flex Self Center.
    /// </summary>
    [StringValue("align-self-center")]
    Center,
    /// <summary>
    /// Flex Self Stretch.
    /// </summary>
    [StringValue("align-self-stretch")]
    Stretch,
    /// <summary>
    /// Flex Self Baseline.
    /// </summary>
    [StringValue("align-self-baseline")]
    Baseline,
}

/// <summary>
/// Flex justify.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum FlexJustify
{
    /// <summary>
    /// Flex Start.
    /// </summary>
    [StringValue("justify-content-start")]
    Start,
    /// <summary>
    /// Flex End.
    /// </summary>
    [StringValue("justify-content-end")]
    End,
    /// <summary>
    /// Flex Start.
    /// </summary>
    [StringValue("justify-content-center")]
    Center,
    /// <summary>
    /// Space Between.
    /// </summary>
    [StringValue("justify-content-between")]
    Between,
    /// <summary>
    /// Space Around.
    /// </summary>
    [StringValue("justify-content-around")]
    Around,
    /// <summary>
    /// Space Evenly.
    /// </summary>
    [StringValue("justify-content-evenly")]
    Evenly
}

/// <summary>
/// Flex gap.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum FlexGap
{
    /// <summary>
    /// Gap 0.
    /// </summary>
    [StringValue("gap-0")]
    Gap_0,
    /// <summary>
    /// Gap 1.
    /// </summary>
    [StringValue("gap-1")]
    Gap_1,
    /// <summary>
    /// Gap 2.
    /// </summary>
    [StringValue("gap-2")]
    Gap_2,
    /// <summary>
    /// Gap 3.
    /// </summary>
    [StringValue("gap-3")]
    Gap_3,
    /// <summary>
    /// Gap 4.
    /// </summary>
    [StringValue("gap-4")]
    Gap_4,
    /// <summary>
    /// Gap 5.
    /// </summary>
    [StringValue("gap-5")]
    Gap_5,
}

/// <summary>
/// Flex Wrap.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum FlexWrap
{
    /// <summary>
    /// No Wrap.
    /// </summary>
    [StringValue("flex-nowrap")]
    NoWrap,
    /// <summary>
    /// Wrap.
    /// </summary>
    [StringValue("flex-wrap")]
    Wrap,
    /// <summary>
    /// Wrap Reverse.
    /// </summary>
    [StringValue("flex-wrap-reverse")]
    WrapReverse
}
