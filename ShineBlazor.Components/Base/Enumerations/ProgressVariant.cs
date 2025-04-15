using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// Progress variant.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    internal enum ProgressVariant
    {
        /// <summary>
        /// Color.
        /// </summary>
        [StringValue("color")]
        Color,
        /// <summary>
        /// Gradient.
        /// </summary>
        [StringValue("gradient")]
        Gradient
    }
}
