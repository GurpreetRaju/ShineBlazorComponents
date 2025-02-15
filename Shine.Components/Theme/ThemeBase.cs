using System.Text;

namespace Shine.Components.Theme
{
    /// <summary>
    /// The default theme.
    /// </summary>
    public abstract class ThemeBase
    {
        /// <summary>
        /// The light theme palette.
        /// </summary>
        protected Palette Light { get; set; }
        
        /// <summary>
        /// The dark theme palette.
        /// </summary>
        protected Palette Dark { get; set; }

        /// <summary>
        /// Builds the theme styles.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="isDarkMode"></param>
        public void BuildStyles(StringBuilder stringBuilder, bool isDarkMode)
        {
            if (isDarkMode && Dark != null)
                Dark.AddVariables(stringBuilder);
            else if (Light != null)
                Light.AddVariables(stringBuilder);            
        }
    }
}
