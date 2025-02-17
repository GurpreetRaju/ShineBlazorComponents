using Shine.Components.Base;

namespace Shine.Components.Common
{
    /// <summary>
    /// A base class for container component that holds child items.
    /// </summary>
    public abstract class ListBase : ShineComponentBase
    {
        /// <summary>
        /// Children.
        /// </summary>
        protected List<IListItem> Children { get; } = new List<IListItem>();

        /// <summary>
        /// Add child component.
        /// </summary>
        /// <param name="item">The child component.</param>
        internal virtual void AddChild(IListItem item)
        {
            Children.Add(item);

            StateHasChanged();
        }
    }
}
