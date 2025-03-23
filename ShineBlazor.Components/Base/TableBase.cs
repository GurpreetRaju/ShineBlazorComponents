using Microsoft.AspNetCore.Components;
using System;

namespace ShineBlazor.Components.Base
{
    public abstract class TableBase : ShineComponentBase
    {
        /// <summary>
        /// The striped rows.
        /// </summary>
        [Parameter]
        public bool Striped { get; set; } = true;

        /// <summary>
        /// The bordered table.
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <inheritdoc/>
        protected override CssClassBuilder CssBuilder => base.CssBuilder
            .WithClass("table border")
            .WithClass("table-bordered", Bordered)
            .WithClass("table-striped", Striped);
    }
}
