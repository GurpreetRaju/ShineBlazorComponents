using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace ShineBlazor.Components.Base
{
    /// <summary>
    /// Provides base functionality for a control.
    /// </summary>
    public abstract class InputControlBase<TValue> : ShineComponentBase
    {
        #region Properties

        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id => Guid.NewGuid();

        /// <summary>
        /// The value.
        /// </summary>
        [Parameter]
        public TValue Value { get; set; }

        /// <summary>
        /// The value changed callback.
        /// </summary>
        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        /// <summary>
        /// Whether the input is required.
        /// </summary>
        [Parameter]
        public bool Required { get; set; }

        /// <summary>
        /// Whether the input is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Whether the input is read only.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The value converter.
        /// </summary>
        [Parameter]
        public ValueConverter<TValue> Converter { get; set; }

        /// <summary>
        /// The culture info.
        /// </summary>
        [Parameter]
        public CultureInfo CultureInfo { get; set; }

        /// <summary>
        /// Equality comparer.
        /// </summary>
        [Parameter]
        public IEqualityComparer<TValue> EqualityComparer { get; set; }

        /// <summary>
        /// The value for format.
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// Error occured while parsing value.
        /// </summary>
        protected string ValueParsingError { get; private set; }

        /// <summary>
        /// The current value as string.
        /// </summary>
        protected string ValueAsString { get; set; }

        #endregion


        #region Overrides

        /// <inheritdoc/>
        public override Task SetParametersAsync(ParameterView parameters)
        {
            try
            {
                if (parameters.TryGetValue(nameof(Value), out TValue newValue) && !Equals(Value, newValue))
                {
                    EnsureDefaults();

                    Value = newValue;
                    ValueAsString = Converter.Convert(newValue, Format, CultureInfo);
                }
            }
            catch (Exception ex)
            {
                ValueParsingError = ex.Message;
            }

            return base.SetParametersAsync(parameters);
        }

        #endregion


        #region Protected Methods

        /// <summary>
        /// Ensure the default values for <see cref="Converter"/> and
        /// <see cref="CultureInfo"/>.
        /// </summary>
        protected virtual void EnsureDefaults()
        {
            Converter ??= new ValueConverter<TValue>();
            CultureInfo ??= CultureInfo.CurrentUICulture;
        }

        /// <summary>
        /// Handles the value changed.
        /// </summary>
        /// <param name="value"></param>
        protected virtual void HandleValueChanged(object value)
        {
            if (TryParseValue(value, out TValue parsedValue) && !Equals(Value, parsedValue))
            {
                Value = parsedValue;
                ValueChanged.InvokeAsync(Value);
                ValueAsString = GetDisplayValue(Value);
            }

            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Try and parse the value.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="parsedValue">The parsed value.</param>
        /// <returns></returns>
        protected virtual bool TryParseValue(object value, out TValue parsedValue)
        {
            EnsureDefaults();
            parsedValue = Converter.ConvertBack(value, out string parsingError);

            if (string.IsNullOrEmpty(parsingError))
            {
                return true;
            }
            else
            {
                ValueParsingError = parsingError;
                return false;
            }
        }

        /// <summary>
        /// Determine if values are equal of <see cref="TValue"/> type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="otherValue"></param>
        /// <returns></returns>
        protected virtual bool Equals(TValue value, TValue otherValue)
        {
            EqualityComparer ??= EqualityComparer<TValue>.Default;

            return EqualityComparer.Equals(value, otherValue);
        }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDisplayValue(TValue value)
        {
            return Converter.Convert(value, Format, CultureInfo);
        }

        #endregion
    }
}
