using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components;

/// <summary>
/// A data grid template column.
/// </summary>
/// <typeparam name="TItem"></typeparam>
public class DataGridTemplateColumn<TItem> : DataGridColumn<TItem, TItem> where TItem : class
{
    /// <summary>
    /// The template for cell.
    /// </summary>
    [Parameter]
    public RenderFragment<TItem?>? CellTemplate { get; set; }

    /// <summary>
    /// Renders the cell.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected internal override RenderFragment RenderCell(TItem item) => __builder =>
    {
        if (CellTemplate != null)
        {
            __builder.AddContent(0, CellTemplate(item));
        }
    };
}
