namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// Typeography.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
[DefaultStringValue("p")]
internal enum Typography
{
    /// <summary>
    /// Represents a paragraph element in the document.
    /// </summary>
    [StringValue("p")]
    Para,
    /// <summary>
    /// Represents a heading 1 element in the document.
    /// </summary>
    [StringValue("h1")]
    Heading1,
    /// <summary>
    /// Represents a heading 2 element in the document.
    /// </summary>
    [StringValue("h2")]
    Heading2,
    /// <summary>
    /// Represents a heading 3 element in the document.
    /// </summary>
    [StringValue("h3")]
    Heading3,
    /// <summary>
    /// Represents a heading 4 element in the document.
    /// </summary>
    [StringValue("h4")]
    Heading4,
    /// <summary>
    /// Represents a heading 5 element in the document.
    /// </summary>
    [StringValue("h5")]
    Heading5,
    /// <summary>
    /// Represents a heading 6 element in the document.
    /// </summary>
    [StringValue("h6")]
    Heading6,
    /// <summary>
    /// Represents an abbreviation element, typically used to display an abbreviated form of a word or phrase with an
    /// optional full description.
    /// </summary>
    [StringValue("abbr")]
    Abbr,
    /// <summary>
    /// Represents preformatted text, preserving whitespace and line breaks as entered.
    /// </summary>
    [StringValue("pre")]
    Pre,
    /// <summary>
    /// Represents a block of code, typically displayed in a monospaced font and used to display programming code.
    /// </summary>
    [StringValue("code")]
    Code,
    /// <summary>
    /// Represents a block of quoted text, typically displayed with indentation and often used to indicate a quotation.
    /// </summary>
    [StringValue("blockquote")]
    Blockquote,
    /// <summary>
    /// Represents a span element, which is an inline container used to group and style inline elements.
    /// </summary>
    [StringValue("span")]
    Span,
    /// <summary>
    /// Represents a division (div) element in the markup.
    /// </summary>
    [StringValue("div")]
    Div
}
