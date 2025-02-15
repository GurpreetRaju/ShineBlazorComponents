
using Microsoft.AspNetCore.Components;

namespace Shine.Components.Base
{
    /// <summary>
    /// The base for a component.
    /// </summary>
    public abstract class ShineComponentBase : ComponentBase, IDisposable
    {
        private const string CssClassAttribute = "class";
        private const string CssStyleAttribute = "style";

        private string m_classAttributeValue;
        private string m_styleAttributeValue;
        
        /// <summary>
        /// The Border.
        /// </summary>
        [Parameter]
        public ComponentEdge Border { get; set; } = ComponentEdge.None;

        /// <summary>
        /// The border color.
        /// </summary>
        [Parameter]
        public Color BorderColor { get; set; } = Color.None;

        /// <summary>
        /// The border size.
        /// </summary>
        [Parameter]
        public uint? BorderSize { get; set; }

        /// <summary>
        /// The border radius.
        /// </summary>
        [Parameter]
        public BorderRadius BorderRadius { get; set; } = BorderRadius.None;

        /// <summary>
        /// The border radius.
        /// </summary>
        [Parameter]
        public uint? RadiusSize { get; set; }

        /// <summary>
        /// Captures the unmatched attributes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        /// <summary>
        /// The component name.
        /// </summary>
        protected abstract string ComponentName { get; }

        /// <summary>
        /// CSS classes for the component including classes extracted from the class attribute added to the component.
        /// </summary>
        protected string CssClasses => CssBuilder.WithClass(m_classAttributeValue).Build();

        /// <summary>
        /// CSS Styles including the styles extracted from the style attribute added to the component.
        /// </summary>
        protected string CssStyles => StyleBuilder.AddStyle(m_styleAttributeValue).Build();

        /// <summary>
        /// Componenet Css Classes builder.
        /// </summary>
        protected virtual CssClassBuilder CssBuilder => CssClassBuilder.Create(ComponentName)
            .WithBorder(Border, BorderColor, BorderSize)
            .WithBorderRadius(BorderRadius, RadiusSize);
        
        /// <summary>
        /// Componenet Css Classes builder.
        /// </summary>
        protected virtual CssStyleBuilder StyleBuilder => CssStyleBuilder.Create();

        /// <summary>
        /// Called when the component is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (AdditionalAttributes != null)
            {
                if (AdditionalAttributes.TryGetValue(CssClassAttribute, out object classValue) && classValue is string cssClass)
                {
                    m_classAttributeValue = cssClass;
                    AdditionalAttributes.Remove(CssClassAttribute);
                }
                if (AdditionalAttributes.TryGetValue(CssStyleAttribute, out object styleValue) && styleValue is string styles)
                {
                    m_styleAttributeValue = styles;
                    AdditionalAttributes.Remove(CssStyleAttribute);
                }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose managed resource.
        /// </summary>
        /// <param name="disposing">Disposing.</param>
        protected virtual void Dispose(bool disposing)
        {

        }
    }
}
