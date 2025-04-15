
namespace ShineBlazor.Components
{
    /// <summary>
    /// Border Edge.
    /// </summary>
    public enum BorderEdge
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// All edges.
        /// </summary>
        All,
        /// <summary>
        /// Left/Start.
        /// </summary>
        Start,
        /// <summary>
        /// Top.
        /// </summary>
        Top,
        /// <summary>
        /// Right/End.
        /// </summary>
        End,
        /// <summary>
        /// Bottom.
        /// </summary>
        Bottom,
        /// <summary>
        /// Left and right.
        /// </summary>
        StartAndEnd,
        /// <summary>
        /// Top and bottom.
        /// </summary>
        TopAndBottom,
    }

    /// <summary>
    /// The border radius.
    /// </summary>
    public enum BorderRadius
    {
        /// <summary>
        /// No radius.
        /// </summary>
        None,
        /// <summary>
        /// Standard radius.
        /// </summary>
        Standard,
        /// <summary>
        /// Top corners.
        /// </summary>
        Top,
        /// <summary>
        /// Right corners.
        /// </summary>
        End,
        /// <summary>
        /// Bottom corners.
        /// </summary>
        Bottom,
        /// <summary>
        /// Left corners.
        /// </summary>
        Start,
        /// <summary>
        /// Circle.
        /// </summary>
        Circle,
        /// <summary>
        /// Pill.
        /// </summary>
        Pill
    }

    /// <summary>
    /// The alignment.
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Start.
        /// </summary>
        Start,
        /// <summary>
        /// Center.
        /// </summary>
        Center,
        /// <summary>
        /// End.
        /// </summary>
        End
    }

    /// <summary>
    /// The view port sizes.
    /// </summary>
    public enum ViewportSize
    {
        /// <summary>
        /// Small.
        /// </summary>
        SM,
        /// <summary>
        /// Medium.
        /// </summary>
        MD,
        /// <summary>
        /// Large.
        /// </summary>
        LG,
        /// <summary>
        /// Extra large.
        /// </summary>
        XL,
        /// <summary>
        /// Extra extra large.
        /// </summary>
        XXL
    }

    /// <summary>
    /// The text wrap.
    /// </summary>
    public enum Wrap
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Wrap text.
        /// </summary>
        Wrap,
        /// <summary>
        /// No wrap.
        /// </summary>
        NoWrap
    }

    /// <summary>
    /// The text transform.
    /// </summary>
    public enum Transform
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Lowercase.
        /// </summary>
        Lowercase,
        /// <summary>
        /// Uppercase.
        /// </summary>
        Uppercase,
        /// <summary>
        /// Capitalize.
        /// </summary>
        Capitalize
    }

    /// <summary>
    /// Elements.
    /// </summary>
    public enum Element
    {
        /// <summary>
        /// Ul.
        /// </summary>
        Ul,
        /// <summary>
        /// Div.
        /// </summary>
        Div
    }

    /// <summary>
    /// The selection mode.
    /// </summary>
    public enum SelectionMode
    {
        /// <summary>
        /// No selection.
        /// </summary>
        None,
        /// <summary>
        /// Single item selection.
        /// </summary>
        Single,
        /// <summary>
        /// Multiple items selection.
        /// </summary>
        Multiple
    }

    /// <summary>
    /// Shadow.
    /// </summary>
    public enum Shadow
    {
        /// <summary>
        /// No shadow.
        /// </summary>
        None,
        /// <summary>
        /// Small.
        /// </summary>
        Sm,
        /// <summary>
        /// Medium
        /// </summary>
        Md,
        /// <summary>
        /// Large.
        /// </summary>
        Lg
    }

    /// <summary>
    /// Input variant.
    /// </summary>
    public enum InputVariant
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default,
        /// <summary>
        /// Outlined.
        /// </summary>
        Outlined,
        /// <summary>
        /// Floating label.
        /// </summary>
        Floating
    }
}
