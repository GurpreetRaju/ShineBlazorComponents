namespace Shine.Components.Theme
{
    /// <summary>
    /// The default theme.
    /// </summary>
    public class DefaultTheme : ThemeBase
    {
        /// <summary>
        /// Initializes the default theme.
        /// </summary>
        public DefaultTheme() 
        {
            Light = new Palette();
            Dark = new Palette();
        }
    }
}
