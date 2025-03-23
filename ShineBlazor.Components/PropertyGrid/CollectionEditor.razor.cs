using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// The collection editor.
    /// </summary>
    public abstract partial class CollectionEditor<TCollection, TItem>
    {
        private TItem _selectedItem;

        /// <inheritdoc/>
        protected override string ComponentName => "array-editor";

        /// <summary>
        /// Collection.
        /// </summary>
        [Parameter]
        public TCollection Collection { get; set; }

        /// <summary>
        /// Collection cahnged callback.
        /// </summary>
        [Parameter]
        public EventCallback<TCollection> CollectionChanged { get; set; }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Collection == null)
            {
                Collection = CreateNewCollection();
            }
        }

        /// <summary>
        /// Creates new collection.
        /// </summary>
        /// <returns></returns>
        protected abstract TCollection CreateNewCollection();

        /// <summary>
        /// Adds a item to collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>Returns the new or updated collection.</returns>
        protected abstract TCollection AddItem(TItem item);

        /// <summary>
        /// Remove an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>Returns the new or updated collection.</returns>
        protected abstract TCollection RemoveItem(TItem item);

        /// <summary>
        /// Add new item.
        /// </summary>
        private void AddNewItem()
        {
            TItem newItem = (TItem)Activator.CreateInstance(typeof(TItem));
            
            Collection = AddItem(newItem);
            CollectionChanged.InvokeAsync(Collection);

            _selectedItem = newItem;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Remove an existing item.
        /// </summary>
        private void RemoveItem()
        {
            Collection = RemoveItem(_selectedItem);
            CollectionChanged.InvokeAsync(Collection);

            _selectedItem = Collection != null ? Collection.FirstOrDefault() : default;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Called when an array item is clicked.
        /// </summary>
        private void OnItemClicked(TItem item)
        {
            _selectedItem = item;

            InvokeAsync(StateHasChanged);
        }
    }
}
