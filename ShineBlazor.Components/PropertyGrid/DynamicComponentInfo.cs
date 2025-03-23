namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// Stores the information for component to render dynamically.
    /// </summary>
    public record DynamicComponentInfo
    {
        /// <summary>
        /// Whether to display the control in popup.
        /// </summary>
        public bool DisplayPopup { get; set; }

        /// <summary>
        /// The component type.
        /// </summary>
        public Type ComponentType { get; set; }

        /// <summary>
        /// The component parameters.
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }
    }
}
