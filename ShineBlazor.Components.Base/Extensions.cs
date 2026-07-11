using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components.Base;

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
    /// Default format for input types.
    /// </summary>
    /// <param name="inputType"></param>
    /// <returns></returns>
    public static string DefaultFormat(this InputType inputType)
    {
        if (inputType == InputType.Date) 
            return DateFormat;
        if (inputType == InputType.Time) 
            return TimeFormat;
        if (inputType == InputType.DateTime) 
            return DateTimeLocalFormat;
        if (inputType == InputType.Month) 
            return MonthFormat;
        return null;
    }

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
            case TypeCode.Boolean:
                return InputType.Checkbox;
        };
        return InputType.Text;
    }

    /// <summary>
    /// Create typed event callback.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="receiver"></param>
    /// <param name="invokableAction"></param>
    /// <returns></returns>
    public static object CreateTypedEventCallback(this Type type, object receiver, Action<object> invokableAction)
    {
        var method = typeof(Extensions).GetMethod(nameof(InvokeCallback), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var genericMethod = method?.MakeGenericMethod(type);

        return genericMethod?.Invoke(receiver, [receiver, invokableAction]);
    }

    /// <summary>
    /// The generic EvantCallback factory method.
    /// </summary>
    private static EventCallback<T> InvokeCallback<T>(object receiver, Action<object> invokableAction)
    {
        return EventCallback.Factory.Create<T>(receiver, (v) => invokableAction(v));
    }

    /// <summary>
    /// Render container.
    /// </summary>
    /// <returns></returns>
    public static RenderFragment RenderFormControlContainer(Guid id, string label, InputVariant variant,
        RenderFragment control)
    {
        return (builder) =>
        {
            string classes = CssClassBuilder.JoinClasses("input-wrapper", variant);
            int seq = 0;
            bool defaultVariant = (variant == null || variant == InputVariant.Default) && control != null;

            builder.OpenElement(seq++, "div");
            builder.AddAttribute(seq++, "class", classes);

            if (!defaultVariant)
            {
                builder.AddContent(seq++, control);
            }
            builder.AddContent(seq++, b =>
            {
                b.OpenElement(0, "label");
                b.AddAttribute(1, "class", "form-label");
                b.AddAttribute(2, "for", id);
                b.AddContent(3, label);
                b.CloseElement();
            });

            if (defaultVariant)
                builder.AddContent(seq++, control);

            builder.CloseElement();
        };
    }
}
