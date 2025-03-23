namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// Array editor
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class ArrayEditor<TItem> : CollectionEditor<TItem[], TItem>
        where TItem : class, new()
    {
        /// <summary>
        /// Adds the item to array.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override TItem[] AddItem(TItem item) => [..Collection, item];

        /// <summary>
        /// Creates new array.
        /// </summary>
        /// <returns></returns>
        protected override TItem[] CreateNewCollection() => [];

        /// <summary>
        /// Remove item from array.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override TItem[] RemoveItem(TItem item) => Collection.Except([item]).ToArray();
    }
}
