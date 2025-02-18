using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Shine.Components.Common
{
    /// <summary>
    /// The value converter.
    /// </summary>
    public class ValueConverter<TValue>
    {
        private readonly static Type _nullableUnderlyingType;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ValueConverter()
        {
            _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));
        }

        /// <summary>
        /// Convert the <see cref="TValue"/> to string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string Convert(TValue value, string format, CultureInfo culture)
        {
            if (value != null)
            {
                return value switch
                {
                    DateTime dateTime => dateTime.ToString(format, CultureInfo.InvariantCulture),
                    DateOnly dateOnly => dateOnly.ToString(format, CultureInfo.InvariantCulture),
                    DateTimeOffset dateoffset => dateoffset.ToString(format, CultureInfo.InvariantCulture),
                    TimeOnly timeOnly => timeOnly.ToString(format, CultureInfo.InvariantCulture),
                    _ => BindConverter.FormatValue(value, culture)?.ToString()
                };
            }
            return null;
        }

        /// <summary>
        /// Convert the string value back to <see cref="TValue"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual TValue ConvertBack(object value, out string parsingError)
        {
            if (_nullableUnderlyingType != null && value == null)
            {
                parsingError = null;
                return default;
            }
            if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out TValue result))
            {
                parsingError = null;
                return result;
            }

            parsingError = "Failed to parse the value.";
            return default;
        }
    }

    /// <summary>
    /// The input type.
    /// </summary>
    public enum InputType
    {
        /// <summary>
        /// Text input.
        /// </summary>
        Text,
        /// <summary>
        /// Color input.
        /// </summary>
        Color,
        /// <summary>
        /// Date input.
        /// </summary>
        Date,
        /// <summary>
        /// Date and time.
        /// </summary>
        DateTime,
        /// <summary>
        /// Email input.
        /// </summary>
        Email,
        /// <summary>
        /// File input.
        /// </summary>
        File,
        /// <summary>
        /// Month input.
        /// </summary>
        Month,
        /// <summary>
        /// Number input.
        /// </summary>
        Number,
        /// <summary>
        /// Password input.
        /// </summary>
        Password,
        /// <summary>
        /// Textarea input.
        /// </summary>
        TextArea,
        /// <summary>
        /// Time input.
        /// </summary>
        Time
    }
}
