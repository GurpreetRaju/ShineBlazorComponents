using System.Text;

namespace Shine.Components.Theme
{
    /// <summary>
    /// Provides the theme colors.
    /// </summary>
    public class Palette
    {
        private const string VariableFormat = "--bs-{0}: {1};";

        /// <summary>
        /// Primary color.
        /// </summary>
        public virtual ThemeColorSet Primary { get; set; }

        /// <summary>
        /// Secondary color.
        /// </summary>
        public virtual ThemeColorSet Secondary { get; set; }

        /// <summary>
        /// Success color.
        /// </summary>
        public virtual ThemeColorSet Success { get; set; }

        /// <summary>
        /// Info color.
        /// </summary>
        public virtual ThemeColorSet Info { get; set; }

        /// <summary>
        /// Warning color.
        /// </summary>
        public virtual ThemeColorSet Warning { get; set; }

        /// <summary>
        /// Danger color.
        /// </summary>
        public virtual ThemeColorSet Danger { get; set; }

        /// <summary>
        /// Light color.
        /// </summary>
        public virtual ThemeColorSet Light { get; set; }

        /// <summary>
        /// Dark color.
        /// </summary>
        public virtual ThemeColorSet Dark { get; set; }

        /// <summary>
        /// The secondary color (RGB - 33, 37, 41).
        /// </summary>
        public virtual string SecondaryColorRgb { get; set; }

        /// <summary>
        /// The tertiary color (RGB - 33, 37, 41).
        /// </summary>
        public virtual string TertiaryColorRgb { get; set; }

        /// <summary>
        /// The secondary background (RGB - 33, 37, 41).
        /// </summary>
        public virtual string SecondaryBackgroundRgb { get; set; }

        /// <summary>
        /// The tertiary background (RGB - 33, 37, 41).
        /// </summary>
        public virtual string TertiaryBackgroundRgb { get; set; }

        /// <summary>
        /// The secondary background (Hex).
        /// </summary>
        public virtual string SecondaryBackgroundHex { get; set; }

        /// <summary>
        /// The tertiary background (Hex).
        /// </summary>
        public virtual string TertiaryBackgroundHex { get; set; }

        /// <summary>
        /// The body font family.
        /// </summary>
        public virtual string BodyFontFamily { get; set; }

        /// <summary>
        /// The body font size.
        /// </summary>
        public virtual string BodyFontSize { get; set; }

        /// <summary>
        /// Any additional variables to add.
        /// </summary>
        public virtual List<string> AdditionalVariables { get; set; }

        /// <summary>
        /// Add css variables.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        protected internal virtual void AddVariables(StringBuilder stringBuilder)
        {
            List<string> variables = new List<string>();

            if (Primary != null)
                variables.AddRange(CreateThemeVariables("primary", Primary));
            if (Secondary != null)
                variables.AddRange(CreateThemeVariables("secondary", Secondary));
            if (Success != null)
                variables.AddRange(CreateThemeVariables("success", Success));
            if (Info != null)
                variables.AddRange(CreateThemeVariables("info", Info));
            if (Warning != null)
                variables.AddRange(CreateThemeVariables("warning", Warning));
            if (Danger != null)
                variables.AddRange(CreateThemeVariables("danger", Danger));
            if (Light != null)
                variables.AddRange(CreateThemeVariables("light", Light));
            if (Dark != null)
                variables.AddRange(CreateThemeVariables("dark", Dark));

            variables.ForEach(v => stringBuilder.Append(v));

            if (!string.IsNullOrWhiteSpace(SecondaryColorRgb))
            {
                stringBuilder.AppendLine(string.Format(VariableFormat, "secondary-color-rgb", SecondaryColorRgb));
                stringBuilder.AppendLine(string.Format(VariableFormat, "secondary-color", $"rgba({SecondaryColorRgb}, 0.75)"));
            }
            if (!string.IsNullOrWhiteSpace(TertiaryColorRgb))
            {
                stringBuilder.AppendLine(string.Format(VariableFormat, "tertiary-color-rgb", TertiaryColorRgb));
                stringBuilder.AppendLine(string.Format(VariableFormat, "tertiary-color", $"rgba({TertiaryColorRgb}, 0.75)"));
            }

            if (!string.IsNullOrWhiteSpace(SecondaryBackgroundRgb))
                stringBuilder.AppendLine(string.Format(VariableFormat, "secondary-bg-rgb", SecondaryBackgroundRgb));

            if (!string.IsNullOrWhiteSpace(TertiaryBackgroundRgb))
                stringBuilder.AppendLine(string.Format(VariableFormat, "tertiary-bg-rgb", TertiaryBackgroundRgb));


            if (!string.IsNullOrWhiteSpace(SecondaryBackgroundHex))
                stringBuilder.AppendLine(string.Format(VariableFormat, "secondary-bg", SecondaryBackgroundHex));

            if (!string.IsNullOrWhiteSpace(TertiaryBackgroundHex))
                stringBuilder.AppendLine(string.Format(VariableFormat, "tertiary-bg", TertiaryBackgroundHex));

            if (!string.IsNullOrWhiteSpace(BodyFontFamily))
                stringBuilder.AppendLine(string.Format(VariableFormat, "body-font-family", BodyFontFamily));

            if (!string.IsNullOrWhiteSpace(BodyFontSize))
                stringBuilder.AppendLine(string.Format(VariableFormat, "body-font-size", BodyFontSize));

            if (AdditionalVariables?.Any() == true)
                AdditionalVariables.ForEach(v => stringBuilder.AppendLine(v));
        }

        /// <summary>
        /// Gets the theme variables.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<string> CreateThemeVariables(string name, ThemeColorSet colorSet)
        {
            List<string> result = [];
            if (colorSet != null)
            {
                if (!string.IsNullOrWhiteSpace(colorSet.Color))
                    result.Add(string.Format(VariableFormat, name, colorSet.Color));
                if (!string.IsNullOrWhiteSpace(colorSet.Rgb))
                    result.Add(string.Format(VariableFormat, $"{name}-rgb", colorSet.Rgb));
                if (!string.IsNullOrWhiteSpace(colorSet.TextEmphasis))
                    result.Add(string.Format(VariableFormat, $"{name}-text-emphasis", colorSet.TextEmphasis));
                if (!string.IsNullOrWhiteSpace(colorSet.BackgroundSubtle))
                    result.Add(string.Format(VariableFormat, $"{name}-bg-subtle", colorSet.BackgroundSubtle));
                if (!string.IsNullOrWhiteSpace(colorSet.Border))
                    result.Add(string.Format(VariableFormat, $"{name}-border-subtle", colorSet.Border));
            }
            return result;
        }
    }

    /// <summary>
    /// Theme color.
    /// </summary>
    public record ThemeColorSet
    {
        /// <summary>
        /// Main color Hex code (e.g. #0d6efd).
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// RGB color. (e.g. 13, 110, 253)
        /// </summary>
        public string Rgb { get; set; }

        /// <summary>
        /// Text emphasis color (Hex).
        /// </summary>
        public string TextEmphasis { get; set; }

        /// <summary>
        /// Background subtle color (Hex).
        /// </summary>
        public string BackgroundSubtle { get; set; }

        /// <summary>
        /// Border subtle color (Hex).
        /// </summary>
        public string Border { get; set; }
    }
}
