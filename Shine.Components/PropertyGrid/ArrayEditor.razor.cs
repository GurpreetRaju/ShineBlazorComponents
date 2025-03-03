using Microsoft.AspNetCore.Components;

namespace Shine.Components.PropertyGrid
{
    /// <summary>
    /// The array editor.
    /// </summary>
    public partial class ArrayEditor
    {
        /// <inheritdoc/>
        protected override string ComponentName => "array-editor";

        /// <summary>
        /// Items.
        /// </summary>
        [Parameter]
        public Array Items { get; set; }
    }
}
