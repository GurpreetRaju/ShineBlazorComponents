using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineBlazor.Components.Base.Enumerations
{
    /// <summary>
    /// The standard colors.
    /// </summary>
    [ClassNamespace("ShineBlazor.Components")]
    internal enum Color
    {
        /// <summary>
        /// Default body color.
        /// </summary>
        [StringValue("body")]
        Body,
        /// <summary>
        /// Main theme color.
        /// </summary>
        [StringValue("primary")]
        Primary,
        /// <summary>
        /// The seconday theme color.
        /// </summary>
        [StringValue("secondary")]
        Secondary,
        /// <summary>
        /// Information.
        /// </summary>
        [StringValue("info")]
        Info,
        /// <summary>
        /// Success.
        /// </summary>
        [StringValue("success")]
        Success,
        /// <summary>
        /// Warning.
        /// </summary
        [StringValue("warning")]
        Warning,
        /// <summary>
        /// Danger.
        /// </summary>
        [StringValue("danger")]
        Danger,
        /// <summary>
        /// Less contrasting colors.
        /// </summary>
        [StringValue("light")]
        Light,
        /// <summary>
        /// Higher contrasting colors.
        /// </summary>
        [StringValue("dark")]
        Dark
    }
}
