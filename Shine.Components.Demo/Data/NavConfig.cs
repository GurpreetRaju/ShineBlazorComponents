namespace Shine.Components.Demo.Data
{
    /// <summary>
    /// The navigation item config.
    /// </summary>
    public record NavConfig
    {
        /// <summary>
        /// Name of the page.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The link.
        /// </summary>
        public string Link { get; set; }
    }
}
