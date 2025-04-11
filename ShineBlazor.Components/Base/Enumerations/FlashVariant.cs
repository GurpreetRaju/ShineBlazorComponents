namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// The variant of flashing component.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    public enum FlashVariant
    {
        /// <summary>
        /// Changes the opacity of component.
        /// </summary>
        [StringValue("opacity")]
        Opacity,
        /// <summary>
        /// Flashes the background-color of the component.
        /// </summary>
        [StringValue("background")]
        Background,
        /// <summary>
        /// Flashes the shadow of the component.
        /// </summary>
        [StringValue("shadow")]
        Shadow
    }
}
