
using Microsoft.AspNetCore.Components;
using Shine.Components;

namespace Shine.Components
{
    /// <summary>
    /// The base for a component.
    /// </summary>
    public class ShineComponentBase : ComponentBase, IDisposable
    {
        private const string CssClassAttribute = "class";
        private const string CssStyleAttribute = "style";

        private string m_classAttributeValue;
        private string m_styleAttributeValue;

        /// <summary>
        /// Captures the unmatched attributes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        /// <summary>
        /// Border.
        /// </summary>
        [Parameter]
        public Border Border { get; set; }

        /// <summary>
        /// CSS classes for the component including classes extracted from the class attribute added to the component.
        /// </summary>
        protected virtual string CssClasses => JoinClasses(BorderClass, string.IsNullOrWhiteSpace(m_classAttributeValue) ? string.Empty : m_classAttributeValue);

        /// <summary>
        /// CSS Styles including the styles extracted from the style attribute added to the component.
        /// </summary>
        protected virtual string CssStyles => string.IsNullOrWhiteSpace(m_styleAttributeValue) ? string.Empty : m_styleAttributeValue;

        /// <summary>
        /// Border Class.
        /// </summary>
        protected string BorderClass
        {
            get
            {
                return Border switch
                {
                    Border.Left => "w3-border-left",
                    Border.LeftBar => "w3-leftbar",
                    Border.Top => "w3-border-top",
                    Border.TopBar => "w3-topbar",
                    Border.Right => "w3-border-right",
                    Border.RightBar => "w3-rightbar",
                    Border.Bottom => "w3-border-bottom",
                    Border.BottomBar => "w3-bottombar",
                    _ => null,
                };
            }
        }

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

        /// <summary>
        /// Joins the css class names.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        protected string JoinClasses(params string[] classes)
        {
            return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
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
