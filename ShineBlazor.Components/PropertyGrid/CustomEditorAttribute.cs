namespace ShineBlazor.Components.PropertyGrid
{
    /// <summary>
    /// The attribute to specify the custom editor to use for editing property value.
    /// The component must have generic type parameter TValue and parameters Value and ValueChanged.
    /// </summary>
    public class CustomEditorAttribute : Attribute
    {
        /// <summary>
        /// Initialize the custom editor attribute.
        /// </summary>
        public CustomEditorAttribute(Type editorType) 
        {
            if (editorType == null)
                throw new ArgumentNullException(nameof(editorType));
    
            EditorType = editorType;
        }

        /// <summary>
        /// The editor type.
        /// </summary>
        public Type EditorType { get; set; }

        /// <summary>
        /// Whether to display the editor inline or in popup.
        /// Default: false.
        /// </summary>
        public bool DisplayInline { get; set; }
    }
}
