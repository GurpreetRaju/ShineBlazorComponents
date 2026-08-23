using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ShineBlazor.Components.Form;

/// <summary>
/// Validates the password for min 8 length, an uppercase letter, lowercase letter, number and special character.
/// </summary>
public partial class PasswordValidationAttribute : ValidationAttribute
{
    /// <summary>
    /// The password regex.
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
    private static partial Regex PasswordRegex();

    /// <summary>
    /// The display name
    /// </summary>
    private string _displayName;

    /// <summary>
    /// Initializes a new instance of <see cref="PasswordValidationAttribute"/>
    /// </summary>
    /// <param name="displayName"></param>
    public PasswordValidationAttribute(string? displayName = null)
    {
        _displayName = displayName ?? string.Empty;
    }

    /// <inheritdoc/>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var password = value as string;

        if (string.IsNullOrEmpty(password))
            return new ValidationResult($"{_displayName} is required.");

        if (password.Length < 8)
            return new ValidationResult($"{_displayName} must be at least 8 characters long.");

        if (!PasswordRegex().IsMatch(password))
            return new ValidationResult($"{_displayName} must contain uppercase and lowercase letters, number and special character.");

        return ValidationResult.Success;
    }
}
