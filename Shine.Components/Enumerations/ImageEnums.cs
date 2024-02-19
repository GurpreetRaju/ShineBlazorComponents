namespace Shine.Components
{
    /// <summary>
    /// Image styles.
    /// </summary>
    [Flags]
    public enum ImageStyle
    {
        /// <summary>
        /// No style.
        /// </summary>
        None,
        /// <summary>
        /// Responsive image.
        /// </summary>
        Responsive,
        /// <summary>
        /// Circle.
        /// </summary>
        Circle,
        /// <summary>
        /// Image border.
        /// </summary>
        Border,
        /// <summary>
        /// Round border.
        /// </summary>
        RoundBorder,
        /// <summary>
        /// Opacity.
        /// </summary>
        Opacity,
        /// <summary>
        /// Opacity on hover.
        /// </summary>
        HoverOpacity,
        /// <summary>
        /// Remove opacity on hover.
        /// </summary>
        HoverOpacityOff,
        /// <summary>
        /// Grayscale image effect.
        /// </summary>
        Grayscale,
        /// <summary>
        /// Grayscale image effect on hover.
        /// </summary>
        HoverGrayscale,
        /// <summary>
        /// Sepia image effect.
        /// </summary>
        Sepia,
        /// <summary>
        /// Sepia image effect on hover.
        /// </summary>
        HoverSepia
    }
}
