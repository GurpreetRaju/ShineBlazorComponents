using System;

namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// String value generator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// The string value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value) => Value = value;
    }
}
