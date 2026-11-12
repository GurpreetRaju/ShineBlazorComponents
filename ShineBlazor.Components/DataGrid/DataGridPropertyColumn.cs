using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components
{
    /// <summary>
    /// The data grid property column.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DataGridPropertyColumn<TItem> : DataGridColumn<TItem, string> where TItem : class
    {
        /// <summary>
        /// The expression for data property.
        /// </summary>
        [Parameter]
        public Func<TItem, string>? DataExpression { get; set; }

        /// <inheritdoc/>
        protected internal override RenderFragment RenderCell(TItem item) => __builder =>
        {
            __builder.AddContent(0, GetCellValue(item));
        };

        /// <inheritdoc/>
        protected internal virtual string? GetCellValue(TItem item)
        {
            return DataExpression == null ? default : DataExpression(item);
        }
    }
}
