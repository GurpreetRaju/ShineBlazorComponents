using Microsoft.AspNetCore.Components;
using Shine.Components.Base;
using System.Globalization;

namespace Shine.Components.Form
{
    /// <summary>
    /// Provides base functionality for a control.
    /// </summary>
    public abstract class InputControlBase<TValue> : ShineComponentBase
    {
        #region Fields

        protected const string DateFormat = "yyyy-MM-dd";                     // Compatible with HTML 'date' inputs
        protected const string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss";   // Compatible with HTML 'datetime-local' inputs
        protected const string MonthFormat = "yyyy-MM";                       // Compatible with HTML 'month' inputs
        protected const string TimeFormat = "HH:mm:ss";

        #endregion

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
        /// Error occured while parsing value.
        /// </summary>
        protected string ValueParsingError { get; private set; }
        
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
        /// Default format for input types.
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        protected virtual string DefaultFormat(InputType inputType) => inputType switch
        {
            InputType.Date => DateFormat,
            InputType.Time => TimeFormat,
            InputType.DateTime => DateTimeLocalFormat,
            InputType.Month => MonthFormat,
            _ => null
        };

        /// <summary>
        /// Determine if values are equal of <see cref="TValue"/> type.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="otherValue"></param>
        /// <returns></returns>
        protected virtual bool Equals(TValue other, TValue otherValue)
        {
            EqualityComparer ??= EqualityComparer<TValue>.Default;

            return EqualityComparer.Equals(Value, otherValue);
        }

        #endregion
    }
}
