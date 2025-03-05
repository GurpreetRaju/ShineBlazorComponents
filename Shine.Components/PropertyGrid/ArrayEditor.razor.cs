using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Shine.Components.PropertyGrid
{
    /// <summary>
    /// The array editor.
    /// </summary>
    public partial class ArrayEditor<TParent>
    {
        private object _selectedItem;
        private Array _existingItems;
        private Type _elementType;

        /// <inheritdoc/>
        protected override string ComponentName => "array-editor";

        /// <summary>
        /// Array property descriptor.
        /// </summary>
        [Parameter]
        public PropertyDescriptor ArrayProperty { get; set; }

        /// <summary>
        /// The parent object of the property.
        /// </summary>
        [Parameter]
        public TParent Parent { get; set; }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (ArrayProperty?.PropertyType.IsArray != true)
                return;

            _existingItems = ArrayProperty.GetValue(Parent) as Array;
            _elementType = ArrayProperty.PropertyType.GetElementType();
        }

        /// <summary>
        /// Add new item.
        /// </summary>
        protected virtual void AddNewItem()
        {
            object newItem = Activator.CreateInstance(_elementType);

            int newSize = (_existingItems?.Length ?? 0) + 1;
            Array newArray = Array.CreateInstance(_elementType, newSize);

            if (_existingItems != null)
                Array.Copy(_existingItems, newArray, _existingItems.Length);

            newArray.SetValue(Convert.ChangeType(newItem, _elementType), newSize - 1);
            ArrayProperty.SetValue(Parent, newArray);
            _existingItems = newArray;

            _selectedItem = newItem;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Remove an existing item.
        /// </summary>
        protected virtual void RemoveItem()
        {
            var array = _existingItems?.Cast<object>() ?? [];
            if (!array.Contains(_selectedItem))
                return;

            Array objArray = array.Where(x => !x.Equals(_selectedItem)).ToArray();
            Array newArray = Array.CreateInstance(_elementType, objArray.Length);
            
            objArray.CopyTo(newArray, 0);

            ArrayProperty.SetValue(Parent, newArray);
            _existingItems = objArray;

            _selectedItem = null;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Called when an array item is clicked.
        /// </summary>
        private void OnItemClicked(object item)
        {
            _selectedItem = item;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Get parameters for dynamic component to show for selected array item.
        /// </summary>
        private void GetDynamicParameters(out Type componentType, out Dictionary<string, object> parameters)
        {
            componentType = typeof(PropertyGrid<>).MakeGenericType(_elementType);
            parameters = new Dictionary<string, object>
            {
                { "TObject", _elementType },
                { "Value", _selectedItem },
                { "PropertyChanged", EventCallback.Factory.Create<string>(this, () => InvokeAsync(StateHasChanged)) }
            };
        }
    }
}
