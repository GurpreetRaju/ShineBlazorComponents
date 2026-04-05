namespace ShineBlazor.Components.Theme
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
            Light = new Palette()
            {
                AdditionalVariables = 
                [
                    "--bs-accordion-active-color: #fff;"
                ]
            };
            Dark = new Palette()
            {
                AdditionalVariables =
                [
                    "--bs-accordion-active-color: #fff;"
                ]
            };
        }
    }
}
