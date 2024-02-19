namespace Shine.Components
{
    /// <summary>
    /// Input style.
    /// </summary>
    public enum InputType
    {
        /// <summary>
        /// Text input.
        /// </summary>
        Text,
        /// <summary>
        /// Color input.
        /// </summary>
        Color,
        /// <summary>
        /// Date input.
        /// </summary>
        Date,
        /// <summary>
        /// Email input.
        /// </summary>
        Email,
        /// <summary>
        /// File input.
        /// </summary>
        File,
        /// <summary>
        /// Hidden input.
        /// </summary>
        Hidden,
        /// <summary>
        /// Month input.
        /// </summary>
        Month,
        /// <summary>
        /// Number input.
        /// </summary>
        Number,
        /// <summary>
        /// Password input.
        /// </summary>
        Password,
        /// <summary>
        /// Textarea input.
        /// </summary>
        TextArea,
    }

    /// <summary>
    /// Input style.
    /// </summary>
    [Flags]
    public enum InputStyle
    {
        /// <summary>
        /// No style.
        /// </summary>
        None,
        /// <summary>
        /// Border.
        /// </summary>
        Border,
        /// <summary>
        /// Round border.
        /// </summary>
        RoundBorder = Border,
    }
}
