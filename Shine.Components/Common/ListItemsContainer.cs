namespace Shine.Components.Common
{
    /// <summary>
    /// A base class for container component that holds child items.
    /// </summary>
    public abstract class ListItemsContainer : ShineComponentBase
    {
        /// <summary>
        /// Children.
        /// </summary>
        protected List<IListItem> Children { get; } = new List<IListItem>();

        /// <summary>
        /// Add child component.
        /// </summary>
        /// <param name="item">The child component.</param>
        internal void AddChild(IListItem item)
        {
            Children.Add(item);

            StateHasChanged();
        }
    }
}
