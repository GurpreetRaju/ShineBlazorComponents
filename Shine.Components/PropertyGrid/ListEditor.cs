namespace Shine.Components.PropertyGrid
{
    /// <summary>
    /// List editor.
    /// </summary>
    public class ListEditor<TItem> : CollectionEditor<List<TItem>, TItem> 
        where TItem : class, new()
    {
        /// <summary>
        /// Add item to list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override List<TItem> AddItem(TItem item)
        {
            Collection.Add(item);

            return Collection;
        }

        /// <summary>
        /// Creates new list.
        /// </summary>
        /// <returns></returns>
        protected override List<TItem> CreateNewCollection()
        {
            return new List<TItem>();
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override List<TItem> RemoveItem(TItem item)
        {
            Collection.Remove(item);

            return Collection;
        }
    }
}
