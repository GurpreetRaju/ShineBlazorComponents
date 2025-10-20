using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using ShineBlazor.Components.Base;

namespace ShineBlazor.Components
{
    /// <summary>
    /// Text Typography.
    /// </summary>
    public class Text : ShineComponentBase
    {
        /// <summary>
        /// The typography.
        /// </summary>
        [Parameter]
        public Typography Typo { get; set; }

        /// <summary>
        /// The child content.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The text content.
        /// </summary>
        [Parameter]
        public string Content { get; set; }

        /// <summary>
        /// The text alignment.
        /// </summary>
        [Parameter]
        public Alignment Alignment { get; set; }

        /// <summary>
        /// The viewport size.
        /// </summary>
        [Parameter]
        public ViewportSize ViewportSize { get; set; }

        /// <summary>
        /// The text wrap.
        /// </summary>
        [Parameter]
        public TextWrap Wrap { get; set; }

        /// <summary>
        /// The text transform.
        /// </summary>
        [Parameter]
        public TextTransform Transform { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => "text";

        /// <inheritdoc/>
        protected override CssClassBuilder CssBuilder => base.CssBuilder.WithText(Alignment, ViewportSize, Wrap, Transform);

        /// <summary>
        /// Renders the tag.
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Typo.ToString());

            builder.AddAttribute(1, "class", CssClasses);

            if (CssStyles is string styles)
                builder.AddAttribute(2, "style", styles);

            if (AdditionalAttributes?.Any() == true)
                builder.AddMultipleAttributes(3, AdditionalAttributes);

            if (Content != null)
                builder.AddContent(4, Content);

            if (ChildContent != null)
                builder.AddContent(5, ChildContent);

            builder.CloseElement();
        }
    }
}
