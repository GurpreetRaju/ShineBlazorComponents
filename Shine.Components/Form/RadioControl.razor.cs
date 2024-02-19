using Microsoft.AspNetCore.Components;
using Shine.Components;

namespace Shine.Components.Form
{
    /// <summary>
    /// Provides code-behind for <see cref="RadioControl"/>
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public partial class RadioControl<TItem> : InputBase<TItem>
    {
        /// <summary>
        /// Items.
        /// </summary>
        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();

        /// <summary>
        /// Function to convert an item to display text.
        /// </summary>
        [Parameter]
        public Func<TItem, string> DisplayFunc { get; set; }

        /// <summary>
        /// CSS classes for the component including classes extracted from the class attribute added to the component.
        /// </summary>
        protected override string CssClasses => JoinClasses("w3-radio", base.CssClasses);
    }
}
