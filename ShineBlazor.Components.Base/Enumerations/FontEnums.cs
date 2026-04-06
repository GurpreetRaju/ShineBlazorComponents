namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// The font size.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    [DefaultStringValue("")]
    internal enum FontSize
    {
        /// <summary>
        /// Small.
        /// </summary>
        [StringValue("font-s")]
        Small,
        /// <summary>
        /// Large
        /// </summary>
        [StringValue("font-l")]
        Large,
        /// <summary>
        /// Extra large.
        /// </summary>
        [StringValue("font-xl")]
        ExtraLarge,
        /// <summary>
        /// Extra extra large.
        /// </summary>
        [StringValue("font-xxl")]
        ExtraExtraLarge
    }
}
