
using Microsoft.AspNetCore.Components;

namespace Shine.Components.Base
{
    /// <summary>
    /// The base for a component.
    /// </summary>
    public abstract class ShineComponentBase : ComponentBase, IDisposable
    {   
        /// <summary>
        /// The css classes.
        /// </summary>
        [Parameter]
        public string Class { get; set; }

        /// <summary>
        /// The css styles.
        /// </summary>
        [Parameter]
        public string Style { get; set; }

        /// <summary>
        /// Adds the shadow.
        /// </summary>
        [Parameter]
        public Shadow? Shadow { get; set; }

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
        protected string CssClasses => CssBuilder.WithClass(Class).Build();

        /// <summary>
        /// CSS Styles including the styles extracted from the style attribute added to the component.
        /// </summary>
        protected string CssStyles => StyleBuilder.AddStyle(Style).Build();

        /// <summary>
        /// Componenet Css Classes builder.
        /// </summary>
        protected virtual CssClassBuilder CssBuilder => CssClassBuilder.Create(ComponentName).WithShadow(Shadow);
        
        /// <summary>
        /// Componenet Css Classes builder.
        /// </summary>
        protected virtual CssStyleBuilder StyleBuilder => CssStyleBuilder.Create();

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
