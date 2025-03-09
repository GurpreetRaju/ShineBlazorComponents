using Shine.Components.Theme;

namespace Shine.Components.Demo.Layout
{
    /// <summary>
    /// Shine Theme.
    /// </summary>
    public class ShineTheme : Theme.DefaultTheme
    {
        public ShineTheme() 
        {
            Light = new LightPalette();
            Dark = new DarkPalette();
        }
    }

    /// <summary>
    /// The light palette.
    /// </summary>
    public class LightPalette : Theme.Palette
    {
        /// <summary>
        /// Initializes the light palette.
        /// </summary>
        public LightPalette()
        {
            Primary = new ThemeColorSet
            {
                Color = "#2081e3",
                Rgb = "32, 129, 227",
                BackgroundSubtle = "#386cbc",
                Border = "#476d99"
            };
            Secondary = new ThemeColorSet
            {
                Color = "#E56B6F",
                Rgb = "229, 107, 111",
            };
        }
    }

    /// <summary>
    /// The light palette.
    /// </summary>
    public class DarkPalette : Theme.Palette
    {
        /// <summary>
        /// Initializes the dark palette.
        /// </summary>
        public DarkPalette()
        {
            Primary = new ThemeColorSet
            {
                Color = "#2081e3",
                Rgb = "32, 129, 227",
                BackgroundSubtle = "#08539e"
            };
            Secondary = new ThemeColorSet
            {
                Color = "#B56576",
                Rgb = "181, 101, 118",
            };
        }
    }
}
