using System.Diagnostics;

namespace Shine.Components.Base
{
    /// <summary>
    /// BuildStyles style.
    /// </summary>
    public class CssStyleBuilder
    {
        private readonly List<string> _styles = new List<string>();

        /// <summary>
        /// Initialize css builder.
        /// </summary>
        private CssStyleBuilder()
        {

        }

        /// <summary>
        /// Create the builder.
        /// </summary>
        /// <returns></returns>
        public static CssStyleBuilder Create()
        {
            return new CssStyleBuilder();
        }

        /// <summary>
        /// Join the styles.
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static string JoinStyles(params string[] styles)
        {
            return string.Join("; ", styles.Where(c => !string.IsNullOrWhiteSpace(c)));
        }

        /// <summary>
        /// Adds the style.
        /// </summary>
        /// <param name="styleName"></param>
        /// <param name="conditionTrueValue"></param>
        /// <param name="conditionFalseValue"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public CssStyleBuilder AddStyle(string styleName, string conditionTrueValue, string conditionFalseValue, bool condition)
        {
            if (!string.IsNullOrWhiteSpace(styleName)) 
            {
                if (condition)
                    AddStyle(styleName + ":" + conditionTrueValue);
                else
                    AddStyle(styleName + ":" + conditionFalseValue);
            }
            return this;
        }

        /// <summary>
        /// Adds the style.
        /// </summary>
        /// <param name="styleName"></param>
        /// <param name="styleValue"></param>
        /// <returns></returns>
        public CssStyleBuilder AddStyle(string styleName, string styleValue, bool condition = true)
        {
            if (condition && !string.IsNullOrWhiteSpace(styleName))
            {
                _styles.Add(styleName + ":" + styleValue);
            }
            return this;
        }

        /// <summary>
        /// Adds the style.
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public CssStyleBuilder AddStyle(string style, bool condition = true)
        {
            if (!string.IsNullOrWhiteSpace(style))
            {
                _styles.Add(style);
            }
            return this;
        }

        /// <summary>
        /// BuildStyles the styles string.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return JoinStyles(_styles.ToArray());
        }
    }
}
