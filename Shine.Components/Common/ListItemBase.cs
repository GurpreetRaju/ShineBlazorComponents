using Microsoft.AspNetCore.Components;
using Shine.Components.Base;

namespace Shine.Components.Common
{
    /// <summary>
    /// List item inteface.
    /// </summary>
    public interface IListItem
    {
        /// <summary>
        /// Hide this item.
        /// </summary>
        void Hide();

        /// <summary>
        /// Show this item.
        /// </summary>
        void Show();
    }

    /// <summary>
    /// A List item component.
    /// </summary>
    public abstract class ListItemBase<TParent> : ShineComponentBase, IListItem where TParent : ListBase
    {
        /// <summary>
        /// Id of this item.
        /// </summary>
        protected Guid Id = Guid.NewGuid();

        /// <summary>
        /// Child content.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The Parent.
        /// </summary>
        [CascadingParameter]
        public TParent Parent { get; set; }

        /// <summary>
        /// Whether this item should be visible or not.
        /// </summary>
        protected bool IsVisibile { get; set; } = true;

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (Parent != null)
            {
                Parent.AddChild(this);
            }
        }

        /// <summary>
        /// Show this item.
        /// </summary>
        public void Show()
        {
            IsVisibile = true;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Hide this item.
        /// </summary>
        public void Hide()
        {
            IsVisibile = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
