
namespace Shine.Components.Base
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
    /// The standard colors.
    /// </summary>
    public enum Color
    {
        /// <summary>
        /// Default body color.
        /// </summary>
        Body,
        /// <summary>
        /// Main theme color.
        /// </summary>
        Primary,
        /// <summary>
        /// The seconday theme color.
        /// </summary>
        Secondary,
        /// <summary>
        /// Information.
        /// </summary>
        Info,
        /// <summary>
        /// Success.
        /// </summary>
        Success,
        /// <summary>
        /// Warning.
        /// </summary>
        Warning,
        /// <summary>
        /// Danger.
        /// </summary>
        Danger,
        /// <summary>
        /// Less contrasting colors.
        /// </summary>
        Light,
        /// <summary>
        /// Higher contrasting colors.
        /// </summary>
        Dark,
        /// <summary>
        /// A custom color.
        /// </summary>
        None
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
}
