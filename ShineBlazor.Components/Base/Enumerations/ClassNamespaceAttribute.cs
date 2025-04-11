using System;

namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// Provides namespace for the generated class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public sealed class ClassNamespaceAttribute : Attribute
    {
        /// <summary>
        /// THe namespace.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="namespace"></param>
        public ClassNamespaceAttribute(string @namespace)
        {
            Namespace = @namespace;
        }
    }

}
