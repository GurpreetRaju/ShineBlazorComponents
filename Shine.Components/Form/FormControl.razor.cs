using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using Shine.Components.Base;
using Microsoft.VisualBasic;

namespace Shine.Components.Form
{
    /// <summary>
    /// Form control.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public partial class FormControl<TValue>
    {
        #region Fields

        private EditContext _oldEditContext;
        private FieldIdentifier _fieldIdentifier;
        private ValidationMessageStore _parsingValidationMessages;

        #endregion


        #region Properties

        /// <summary>
        /// Current edit context.
        /// </summary>
        [CascadingParameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// The input type.
        /// </summary>
        [Parameter]
        public InputType InputType { get; set; }

        /// <summary>
        /// Label text.
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// For expression used for validation message.
        /// </summary>
        [Parameter]
        public Expression<Func<TValue>> ValueExpression { get; set; }

        /// <summary>
        /// Function to convert an item to display text.
        /// </summary>
        [Parameter]
        public Func<TValue, string> DisplayFunc { get; set; }

        /// <summary>
        /// Whether to show the text value only.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The placeholder.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// The size.
        /// </summary>
        [Parameter]
        public Size Size { get; set; }

        /// <summary>
        /// The css class for the control.
        /// </summary>
        [Parameter]
        public string ControlClass { get; set; }

        /// <summary>
        /// The css style for the control.
        /// </summary>
        [Parameter]
        public string ControlStyle { get; set; }

        /// <summary>
        /// The value for format.
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => "form-control-wrapper";

        /// <inheritdoc/>
        protected virtual CssClassBuilder ControlCssBuilder => CssClassBuilder.Create("form-control")
            .WithClass(ControlClass)
            .WithClass("form-control-sm", Size == Size.Small)
            .WithClass("form-control-lg", Size == Size.Large);

        /// <summary>
        /// The validation messages.
        /// </summary>
        protected IEnumerable<string> ValidationMessages
        {
            get
            {
                if (ValueExpression == null && EditContext == null) return Enumerable.Empty<string>();

                return EditContext.GetValidationMessages(_fieldIdentifier);
            }
        }

        /// <summary>
        /// The current value as string.
        /// </summary>
        protected string ValueAsString { get; set; }

        #endregion


        #region Overrides

        /// <inheritdoc/>
        public override Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.TryGetValue(nameof(Value), out TValue newValue) && !Equals(Value, newValue))
            {
                EnsureDefaults();

                Value = newValue;
                ValueAsString = Converter.Convert(newValue, Format, CultureInfo);
            }

            return base.SetParametersAsync(parameters);
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            EnsureDefaults();

            if (EditContext != null && ValueExpression != null)
            {
                _fieldIdentifier = FieldIdentifier.Create(ValueExpression);

                if (EditContext != _oldEditContext)
                {
                    UnsubscribeValidationStateChangedListener();
                    EditContext.OnValidationStateChanged += OnValidationStateChanged;
                    _oldEditContext = EditContext;
                }
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            UnsubscribeValidationStateChangedListener();

            base.Dispose(disposing);
        }

        /// <inheritdoc/>
        protected override void EnsureDefaults()
        {
            base.EnsureDefaults();

            Format ??= DefaultFormat(InputType);
        }

        /// <summary>
        /// Handles the value changed.
        /// </summary>
        /// <param name="value"></param>
        protected override void HandleValueChanged(object value)
        {
            base.HandleValueChanged(value);

            if (!string.IsNullOrEmpty(ValueParsingError))
            {
                _parsingValidationMessages?.Clear();

                _parsingValidationMessages ??= new ValidationMessageStore(EditContext);
                _parsingValidationMessages.Add(_fieldIdentifier, ValueParsingError);
            }
            else
            {
                ValueAsString = GetDisplayValue(Value);
            }

            EditContext.NotifyFieldChanged(_fieldIdentifier);
        }

        #endregion


        #region Protected and Private Methods

        /// <summary>
        /// Gets the display value.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDisplayValue(TValue value)
        {
            if (DisplayFunc == null)
                return Converter.Convert(value, Format, CultureInfo);

            return DisplayFunc.Invoke(value);
        }

        /// <summary>
        /// Unsubscribe the Validation State Changed listener.
        /// </summary>
        private void UnsubscribeValidationStateChangedListener()
        {
            if (_oldEditContext != null)
            {
                _oldEditContext.OnValidationStateChanged -= OnValidationStateChanged;
            }
        }

        /// <summary>
        /// Called when the validation state is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ValidationStateChangedEventArgs"/> args.</param>
        private async void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs args)
        {
            await InvokeAsync(StateHasChanged);
        }

        #endregion
    }
}
