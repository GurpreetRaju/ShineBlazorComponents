using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components.Base;

/// <summary>
/// A component with border.
/// </summary>
public abstract class BackgroundComponentBase : ShineComponentBase
{
    /// <summary>
    /// The background color. Default: None.
    /// </summary>
    [Parameter]
    public Color BackgroundColor { get; set; }

    /// <inheritdoc/>
    protected override CssClassBuilder CssBuilder => base.CssBuilder.WithBackground(BackgroundColor);
}
