using Microsoft.AspNetCore.Components;
using Shine.Components;

namespace Shine.Components.Form
{
    /// <summary>
    /// Provides the code-behind for <see cref="FormInput"/>.
    /// </summary>
    public partial class FormInput : InputBase<string>
    {
        /// <summary>
        /// Input type.
        /// </summary>
        [Parameter]
        public InputType InputType { get; set; }

        /// <summary>
        /// Input style.
        /// </summary>
        [Parameter]
        public InputStyle InputStyle { get; set; }

        /// <summary>
        /// CSS classes for the component including classes extracted from the class attribute added to the component.
        /// </summary>
        protected override string CssClasses => JoinClasses("w3-input", base.CssClasses);
    }
}
