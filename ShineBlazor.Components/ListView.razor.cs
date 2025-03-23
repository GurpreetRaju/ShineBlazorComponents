using Microsoft.AspNetCore.Components;
using ShineBlazor.Components.Base;

namespace ShineBlazor.Components
{
    /// <summary>
    /// The list view.
    /// </summary>
    public partial class ListView<TItem>
    {
        /// <summary>
        /// Items collection.
        /// </summary>
        [Parameter]
        public ICollection<TItem> Items { get; set; }

        /// <summary>
        /// Item template.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// The function to convert item to text.
        /// </summary>
        [Parameter]
        public Func<TItem, string> ItemToText { get; set; }

        /// <summary>
        /// The css class for items.
        /// </summary>
        [Parameter]
        public string ItemClass { get; set; }

        /// <summary>
        /// The list color.
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Body;

        /// <summary>
        /// The list size.
        /// </summary>
        [Parameter]
        public Size Size { get; set; }

        /// <summary>
        /// The list text variant.
        /// </summary>
        [Parameter]
        public bool TextVariant { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => "list-view";

        /// <inheritdoc/>
        protected override CssClassBuilder CssBuilder => base.CssBuilder
            .WithClass(() =>
            {
                string variant = "list-view-";
                if (TextVariant) variant = variant + "text-";
                return variant + Color.ToString().ToLowerInvariant();
            })
            .WithClass(() => $"list-view-{Size.ToString().ToLowerInvariant()}");

        /// <summary>
        /// CSS classes for items.
        /// </summary>
        protected CssClassBuilder ItemCssBuilder => CssClassBuilder.Create("list-view-item").WithClass(ItemClass);
    }
}
