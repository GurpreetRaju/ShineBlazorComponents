using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Shine.Components.PropertyGrid;

namespace Shine.Components.Base
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        private static readonly string DateFormat = "yyyy-MM-dd";                     // Compatible with HTML 'date' inputs
        private static readonly string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss";   // Compatible with HTML 'datetime-local' inputs
        private static readonly string MonthFormat = "yyyy-MM";                       // Compatible with HTML 'month' inputs
        private static readonly string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// Extension method to convert <see cref="InputType"/> to string.
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public static string ConvertToString(this InputType inputType)
        {
            return inputType == InputType.DateTime ? "datetime-local" : inputType.ToString().ToLowerInvariant();
        }

        /// <summary>
        /// Default format for input types.
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public static string DefaultFormat(this InputType inputType) => inputType switch
        {
            InputType.Date => DateFormat,
            InputType.Time => TimeFormat,
            InputType.DateTime => DateTimeLocalFormat,
            InputType.Month => MonthFormat,
            _ => null
        };

        /// <summary>
        /// Gets the input type for given type code.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public static InputType GetInputType(this TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return InputType.Number;
                case TypeCode.DateTime:
                    return InputType.DateTime;
            };
            return InputType.Text;
        }

        /// <summary>
        /// Create typed event callback.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <param name="invokableAction"></param>
        /// <returns></returns>
        public static object CreateTypedEventCallback(this ComponentBase component, Type type, Action<object> invokableAction)
        {
            var method = typeof(Extensions).GetMethod(nameof(InvokeCallback), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var genericMethod = method?.MakeGenericMethod(type);

            return genericMethod?.Invoke(component, [component, invokableAction]);
        }

        /// <summary>
        /// The generic EvantCallback factory method.
        /// </summary>
        private static EventCallback<T> InvokeCallback<T>(ComponentBase component, Action<object> invokableAction)
        {
            return EventCallback.Factory.Create<T>(component, (v) => invokableAction(v));
        }
    }
}
