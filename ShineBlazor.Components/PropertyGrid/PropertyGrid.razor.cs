using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// The property grid.
    /// </summary>
    /// <typeparam name="TObject">The type of object to edit.</typeparam>
    public partial class PropertyGrid<TObject>
    {
        #region Fields

        /// <summary>
        /// The property infos.
        /// </summary>
        private static readonly PropertyDescriptor[] s_propertyDescriptors;

        #endregion


        #region Constructor

        /// <summary>
        /// Initialize property types and descirptors.
        /// </summary>
        static PropertyGrid()
        {            
            var propertyDescriptors = new List<PropertyDescriptor>();

            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(typeof(TObject))) 
            {
                if (!propertyDescriptor.IsBrowsable) continue;

                propertyDescriptors.Add(propertyDescriptor);
            }

            s_propertyDescriptors = propertyDescriptors.ToArray();
        }

        #endregion


        #region Properties

        /// <summary>
        /// The value to edit.
        /// </summary>
        [Parameter]
        public TObject Value { get; set; }

        /// <summary>
        /// The value change callback.
        /// </summary>
        [Parameter]
        public EventCallback<TObject> ValueChanged { get; set; }

        /// <summary>
        /// The property change callback.
        /// </summary>
        [Parameter]
        public EventCallback<string> PropertyChanged { get; set; }

        #endregion


        #region Overrides

        /// <inheritdoc/>
        protected override string ComponentName => "property-grid";

        /// <inheritdoc/>
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            bool isChanged = false;
            if (parameters.TryGetValue(nameof(Value), out TObject value)
                && value != Value)
            {
                Value = value;
                isChanged = true;
            }

            await base.SetParametersAsync(parameters);

            if (isChanged)
                await InvokeAsync(StateHasChanged);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Value == null)
            {
                Value = new();
                ValueChanged.InvokeAsync(Value);
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Called when the property value changes.
        /// </summary>
        /// <param name="propertyName"></param>
        internal void PropertyValueChanged(string propertyName)
        {
            PropertyChanged.InvokeAsync(propertyName);
        }

        #endregion
    }
}
