using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ShineBlazor.Components.Form;

/// <summary>
/// Match field value with another field.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MatchFieldAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    /// <summary>
    /// Initializes a new instance of <see cref="MatchFieldAttribute"/>.
    /// </summary>
    /// <param name="comparisonProperty"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public MatchFieldAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty ?? throw new ArgumentNullException(nameof(comparisonProperty));
    }

    /// <inheritdoc/>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (propertyInfo == null)
        {
            return new ValidationResult($"Unknown property: {_comparisonProperty}");
        }

        object? comparisonValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

        if (value != null && !value.Equals(comparisonValue))
        {
            string errorMessage = ErrorMessage ?? $"{validationContext.DisplayName} must match {_comparisonProperty}.";
            return new ValidationResult(errorMessage, new[] { validationContext.MemberName! });
        }

        return ValidationResult.Success;
    }
}
