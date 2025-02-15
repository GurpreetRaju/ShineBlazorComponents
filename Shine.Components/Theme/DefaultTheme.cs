namespace Shine.Components.Theme
{
    public class DefaultTheme : ThemeBase
    {
        /// <summary>
        /// Initializes the default theme.
        /// </summary>
        public DefaultTheme() 
        {
            Light = new LightPalette();
            Dark = new DarkPalette();
        }
    }

    /// <summary>
    /// Light palette.
    /// </summary>
    public class LightPalette : Palette
    {
        /// <summary>
        /// Initializes the light palette.
        /// </summary>
        public LightPalette() 
        {
            Primary = new ThemeColorSet
            {
                Color = "#355070",
                Rgb = "53, 80, 112",
            };
            Secondary = new ThemeColorSet
            {
                Color = "#E56B6F",
                Rgb = "229, 107, 111",
            };
        }
    }

    /// <summary>
    /// Dark palette.
    /// </summary>
    public class DarkPalette : Palette
    {
        /// <summary>
        /// Initializes the dark palette.
        /// </summary>
        public DarkPalette() 
        {
            Primary = new ThemeColorSet
            {
                Color = "#213145",
                Rgb = "33, 49, 69",
            };
            Secondary = new ThemeColorSet
            {
                Color = "#B56576",
                Rgb = "181, 101, 118",
            };
        }
    }
}
