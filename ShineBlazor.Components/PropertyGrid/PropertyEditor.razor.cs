using Microsoft.AspNetCore.Components;
using ShineBlazor.Components.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// Provides the editor for the property.
    /// </summary>
    public partial class PropertyEditor<TParent>
    {
        #region Fields

        /// <summary>
        /// The allowed values for the property.
        /// </summary>
        protected Array _allowedValues;

        /// <summary>
        /// Whether the input is required.
        /// </summary>
        protected bool _required;

        /// <summary>
        /// Error occured while parsing value.
        /// </summary>
        protected string _valueParsingError;

        /// <summary>
        /// Whether the targetType is nullable targetType.
        /// </summary>
        protected bool _isNullableType;

        /// <summary>
        /// The underlying targetType if property targetType is nullable targetType.
        /// </summary>
        protected Type _underlyingType;

        /// <summary>
        /// The element targetType if property targetType is array or list targetType.
        /// </summary>
        protected Type _elementType;

        /// <summary>
        /// Property Type.
        /// </summary>
        protected Type PropertyType => PropertyDescriptor?.PropertyType;

        /// <summary>
        /// The current value for property.
        /// </summary>
        protected object _propertyValue;

        /// <summary>
        /// The targetType converter.
        /// </summary>
        protected TypeConverter _converter;

        /// <summary>
        /// Whether the input control is read only.
        /// </summary>
        protected bool _readOnly;

        /// <summary>
        /// The component control.
        /// </summary>
        private ComponentControl _componentControl;

        /// <summary>
        /// Controls the display of popup if property requires.
        /// </summary>
        private bool _showPopup;

        /// <summary>
        /// Custom editor attribute.
        /// </summary>
        private CustomEditorAttribute _editorAttribute;

        #endregion


        #region Properties

        /// <summary>
        /// The property descriptor.
        /// </summary>
        [Parameter]
        public PropertyDescriptor PropertyDescriptor { get; set; }

        /// <summary>
        /// The parent object of the property.
        /// </summary>
        [Parameter]
        public TParent Parent { get; set; }

        /// <summary>
        /// The culture info.
        /// </summary>
        [Parameter]
        public CultureInfo CultureInfo { get; set; }

        /// <summary>
        /// The value for format.
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// The parent grid.
        /// </summary>
        [CascadingParameter]
        private PropertyGrid<TParent> ParentGrid { get; set; }

        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id => Guid.NewGuid();

        /// <summary>
        /// The current value for property.
        /// </summary>
        protected object PropertyValue => _propertyValue;

        #endregion


        #region Overrides

        /// <inheritdoc/>
        protected override string ComponentName => "property-editor";

        /// <inheritdoc/>
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            bool isChanged = (parameters.TryGetValue(nameof(PropertyDescriptor), out PropertyDescriptor propertyDescriptor)
                    && propertyDescriptor != PropertyDescriptor)
                || (parameters.TryGetValue(nameof(Parent), out TParent parent) && parent != Parent);

            CultureInfo ??= CultureInfo.CurrentUICulture;

            await base.SetParametersAsync(parameters);

            if (isChanged)
                Initialize(propertyDescriptor);
        }

        #endregion


        #region Protected Methods

        /// <summary>
        /// Initialize the properties.
        /// </summary>
        /// <param name="propertyDescriptor"></param>
        protected virtual void Initialize(PropertyDescriptor propertyDescriptor)
        {
            PropertyDescriptor = propertyDescriptor;

            if (PropertyDescriptor == null)
                return;

            _underlyingType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType);
            _elementType = GetCollectionElementType(PropertyDescriptor.PropertyType);
            _isNullableType = _underlyingType != null;
            _required = PropertyDescriptor.Attributes.OfType<RequiredAttribute>().Any();
            _converter = PropertyDescriptor.Converter;
            _readOnly = PropertyDescriptor.IsReadOnly;

            try
            {
                _propertyValue = PropertyDescriptor.GetValue(Parent);
            }
            catch (Exception ex)
            {
                _valueParsingError = ex.Message;
            }

            UpdateAllowedValues();

            var type = _underlyingType ?? PropertyType;
            UpdateComponentControl(type);
        }

        /// <summary>
        /// Parse the value and set to property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected virtual void SetValue(object value)
        {
            try
            {
                if (value.GetType() != PropertyType)
                {
                   value = _converter.ConvertFrom(value);
                }

                PropertyDescriptor.SetValue(Parent, value);
                _propertyValue = value;

                if (ParentGrid != null && PropertyDescriptor != null)
                {
                    ParentGrid.PropertyValueChanged(PropertyDescriptor.Name);
                }
            }
            catch (Exception ex)
            {
                _valueParsingError = ex.Message;
            }
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetValue(object value)
        {
            if (value != null)
            {
                return value switch
                {
                    DateTime dateTime => dateTime.ToString(Format, CultureInfo.InvariantCulture),
                    DateOnly dateOnly => dateOnly.ToString(Format, CultureInfo.InvariantCulture),
                    DateTimeOffset dateoffset => dateoffset.ToString(Format, CultureInfo.InvariantCulture),
                    TimeOnly timeOnly => timeOnly.ToString(Format, CultureInfo.InvariantCulture),
                    _ => BindConverter.FormatValue(value, CultureInfo)?.ToString()
                };
            }
            
            return null;
        }

        /// <summary>
        /// Gets the targetType of component to render.
        /// </summary>
        /// <returns></returns>
        protected virtual DynamicComponentInfo GetComponentToRender()
        {
            try
            {
                switch (_componentControl)
                {
                    case ComponentControl.Text:
                        return new DynamicComponentInfo
                        {
                            ComponentType = typeof(Text),
                            Parameters = new Dictionary<string, object>
                            {
                                { nameof(Text.Content), _propertyValue?.ToString() },
                                { nameof(Text.Typo), Typography.Span },
                            }
                        };
                    case ComponentControl.Array:
                        return new DynamicComponentInfo
                        {
                            DisplayPopup = true,
                            ComponentType = typeof(ArrayEditor<>).MakeGenericType(_elementType),
                            Parameters = new Dictionary<string, object>
                            {
                                { "TItem", _elementType },
                                { nameof(ArrayEditor<TParent>.Collection), _propertyValue },
                                { nameof(ArrayEditor<TParent>.CollectionChanged), PropertyType.CreateTypedEventCallback(this, SetValue) }
                            }
                        };
                    case ComponentControl.List:
                        return new DynamicComponentInfo
                        {
                            DisplayPopup = true,
                            ComponentType = typeof(ListEditor<>).MakeGenericType(_elementType),
                            Parameters = new Dictionary<string, object>
                            {
                                { "TItem", _elementType },
                                { nameof(ListEditor<TParent>.Collection), _propertyValue },
                                { nameof(ListEditor<TParent>.CollectionChanged), PropertyType.CreateTypedEventCallback(this, SetValue) }
                            }
                        };
                    case ComponentControl.PropertyGrid:
                        return new DynamicComponentInfo
                        {
                            DisplayPopup = true,
                            ComponentType = typeof(PropertyGrid<>).MakeGenericType(PropertyType),
                            Parameters = new Dictionary<string, object>
                            {
                                { "TObject", PropertyType },
                                { nameof(PropertyGrid<TParent>.Value), _propertyValue },
                                { nameof(PropertyGrid<TParent>.ValueChanged), PropertyType.CreateTypedEventCallback(this, SetValue) }
                            }
                        };
                    case ComponentControl.DropDown:
                        return new DynamicComponentInfo
                        {
                            ComponentType = typeof(DropDown<>).MakeGenericType(PropertyType),
                            Parameters = new Dictionary<string, object>
                            {
                                { "TItem", PropertyType },
                                { nameof(DropDown<TParent>.Items), _allowedValues },
                                { nameof(DropDown<TParent>.SelectedItem), _propertyValue },
                                { nameof(DropDown<TParent>.SelectedItemChanged), PropertyType.CreateTypedEventCallback(this, SetValue) },
                                { nameof(DropDown<TParent>.SelectionMode), SelectionMode.Single }
                            }
                        };
                    case ComponentControl.Custom:
                        return new DynamicComponentInfo
                        {
                            DisplayPopup = !_editorAttribute.DisplayInline,
                            ComponentType = _editorAttribute.EditorType,
                            Parameters = new Dictionary<string, object>
                            {
                                { "Value", _propertyValue },
                                { "ValueChanged", PropertyType.CreateTypedEventCallback(this, SetValue) }
                            }
                        };
                    default:
                        break;
                }
            }
            catch
            {
                // No-op
            }

            return new DynamicComponentInfo
            {
                ComponentType = typeof(InputControl<>).MakeGenericType(PropertyType),
                Parameters = new Dictionary<string, object>
                {
                    { "TValue", PropertyType },
                    { nameof(InputControl<TParent>.Value), _propertyValue },
                    { nameof(InputControl<TParent>.ValueChanged), PropertyType.CreateTypedEventCallback(this, SetValue) },
                    { nameof(InputControl<TParent>.Required), _required },
                    { nameof(InputControl<TParent>.ReadOnly), _readOnly }
                }
            };
        }


        /// <summary>
        /// Updates the allowed values for property.
        /// </summary>
        protected virtual void UpdateAllowedValues()
        {
            var allowedValuesAttr = PropertyDescriptor.Attributes
                .OfType<AllowedValuesAttribute>().FirstOrDefault();

            if (PropertyType.IsEnum)
            {
                _allowedValues = Enum.GetValues(PropertyDescriptor.PropertyType);
            }
            else if (allowedValuesAttr != null)
            {
                _allowedValues = CastArray(PropertyType, allowedValuesAttr.Values);
            }
            else if (PropertyType == typeof(bool))
            {
                _allowedValues = _isNullableType ? new bool?[] { null, true, false }
                    : new bool[] { true, false };
            }
            else
            {
                _allowedValues = null;
            }
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Udpate the <see cref="_componentControl"/>.
        /// </summary>
        /// <param name="type"></param>
        private void UpdateComponentControl(Type type)
        {
            if (PropertyDescriptor.IsReadOnly)
            {
                _componentControl = ComponentControl.Text;
            }
            else if (PropertyDescriptor.Attributes.OfType<CustomEditorAttribute>().FirstOrDefault() is CustomEditorAttribute editorAttribute)
            {
                _componentControl = ComponentControl.Custom;
                _editorAttribute = editorAttribute;
            }
            else if (!(type.IsPrimitive ||
                    type.IsEnum ||
                    type == typeof(string) ||
                    type == typeof(decimal) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTime?) ||
                    type == typeof(TimeSpan) ||
                    type == typeof(TimeSpan?) ||
                    type == typeof(Guid)) &&
                !type.IsArray &&
                !typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            {
                _componentControl = ComponentControl.PropertyGrid;
            }
            else if (PropertyType.IsArray)
            {
                _componentControl = ComponentControl.Array;
            }
            else if (PropertyType.IsGenericType && PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                _componentControl = ComponentControl.List;
            }
            else if (_allowedValues != null && _allowedValues.Length > 0)
            {
                _componentControl = ComponentControl.DropDown;
            }
            else
            {
                _componentControl= ComponentControl.Input;
            }
        }

        /// <summary>
        /// Shows the popup.
        /// </summary>
        private void ShowPopup()
        {
            _showPopup = true;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Hides the popup.
        /// </summary>
        private void HidePopup()
        {
            _showPopup = false;

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Cast an array to given targetType.
        /// </summary>
        private static Array CastArray(Type targetType, ICollection<object> values)
        {
            if (values == null)
                return null;

            var array = Array.CreateInstance(targetType, values.Count);
            int i = 0;

            foreach (var item in values)
            {
                if (item == null || targetType.IsInstanceOfType(item))
                    array.SetValue(item, i++);
            }

            return array;
        }

        /// <summary>
        /// Gets the collection element targetType.
        /// </summary>
        /// <param name="collectionType"></param>
        /// <returns></returns>
        private static Type GetCollectionElementType(Type collectionType)
        {
            if (collectionType.IsArray)
            {
                return collectionType.GetElementType();
            }
            Type[] genericArgs = collectionType.GetGenericArguments();
            if (genericArgs.Length > 0)
            {
                return genericArgs[0];
            }

            return null;
        }

        #endregion
    }

    /// <summary>
    /// The component control.
    /// </summary>
    enum ComponentControl
    {
        /// <summary>
        /// Array Editor.
        /// </summary>
        Array,
        /// <summary>
        /// Drop down.
        /// </summary>
        DropDown,
        /// <summary>
        /// Input control.
        /// </summary>
        Input,
        /// <summary>
        /// List Editor.
        /// </summary>
        List,
        /// <summary>
        /// Property Grid.
        /// </summary>
        PropertyGrid,
        /// <summary>
        /// Text control.
        /// </summary>
        Text, 
        /// <summary>
        /// Custom editor.
        /// </summary>
        Custom
    }
}
