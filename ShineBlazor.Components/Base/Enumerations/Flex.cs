namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// Flex Align Items.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    internal enum FlexAlign
    {
        /// <summary>
        /// Flex Start.
        /// </summary>
        [StringValue("start")]
        Start,
        /// <summary>
        /// Flex End.
        /// </summary>
        [StringValue("end")]
        End,
        /// <summary>
        /// Center.
        /// </summary>
        [StringValue("center")]
        Center,
        /// <summary>
        /// Stretch.
        /// </summary>
        [StringValue("stretch")]
        Stretch,
        /// <summary>
        /// Baseline.
        /// </summary>
        [StringValue("baseline")]
        Baseline
    }

    /// <summary>
    /// Flex Align Content.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    internal enum FlexContent
    {
        /// <summary>
        /// Flex Start.
        /// </summary>
        [StringValue("start")]
        Start,
        /// <summary>
        /// Flex End.
        /// </summary>
        [StringValue("end")]
        End,
        /// <summary>
        /// Flex Start.
        /// </summary>
        [StringValue("center")]
        Center,
        /// <summary>
        /// Space Between.
        /// </summary>
        [StringValue("between")]
        Between,
        /// <summary>
        /// Space Around.
        /// </summary>
        [StringValue("around")]
        Around,
        /// <summary>
        /// Space Evenly.
        /// </summary>
        [StringValue("evenly")]
        Evenly
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
        [StringValue("nowrap")]
        NoWrap,
        /// <summary>
        /// Wrap.
        /// </summary>
        [StringValue("wrap")]
        Wrap,
        /// <summary>
        /// Wrap Reverse.
        /// </summary>
        [StringValue("wrap-reverse")]
        WrapReverse
    }
}
