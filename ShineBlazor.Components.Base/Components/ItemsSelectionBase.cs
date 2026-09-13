using Microsoft.AspNetCore.Components;

namespace ShineBlazor.Components.Base;

/// <summary>
/// Provides base functionality for controls that support item selection.
/// </summary>
public abstract class ItemsSelectionBase<TItem> : ShineComponentBase
{
    /// <summary>
    /// The selection mode.
    /// </summary>
    [Parameter]
    public SelectionMode SelectionMode { get; set; }

    /// <summary>
    /// The selected item.
    /// </summary>
    [Parameter]
    public TItem SelectedItem { get; set; }

    /// <summary>
    /// The selected item changed.
    /// </summary>
    [Parameter]
    public EventCallback<TItem> SelectedItemChanged { get; set; }

    /// <summary>
    /// The selected items.
    /// </summary>
    [Parameter]
    public ICollection<TItem> SelectedItems { get; set; }

    /// <summary>
    /// The selected items changed.
    /// </summary>
    [Parameter]
    public EventCallback<ICollection<TItem>> SelectedItemsChanged { get; set; }

    /// <summary>
    /// Items.
    /// </summary>
    [Parameter]
    public IEnumerable<TItem> Items { get; set; } = [];

    /// <summary>
    /// Item clicked callback.
    /// </summary>
    [Parameter]
    public EventCallback<TItem> ItemClicked { get; set; }

    /// <summary>
    /// Whether the component is disabled.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The equality comparer.
    /// </summary>
    [Parameter]
    public IEqualityComparer<TItem> EqualityComparer { get; set; }

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        EqualityComparer ??= EqualityComparer<TItem>.Default;
    }

    /// <summary>
    /// Handles the item clicked.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void HandleItemClicked(TItem item)
    {
        if (SelectionMode != SelectionMode.None)
        {
            if (SelectionMode == SelectionMode.Single)
            {
                SelectedItem = item;
                SelectedItemChanged.InvokeAsync(SelectedItem);
            }
            else
            {
                // Toggle for multi selection.
                if (SelectedItems?.Contains(item) == true)
                {
                    SelectedItems.Remove(item);
                }
                else
                {
                    SelectedItems ??= new HashSet<TItem>();
                    SelectedItems.Add(item);
                }
                SelectedItemsChanged.InvokeAsync(SelectedItems);
            }
            InvokeAsync(StateHasChanged);
        }

        if (ItemClicked.HasDelegate)
        {
            ItemClicked.InvokeAsync(item);
        }
    }

    /// <summary>
    /// Check if the item is selected.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected bool IsItemSelected(TItem item) => (SelectionMode == SelectionMode.Multiple && SelectedItems.Contains(item, EqualityComparer)) ||
        (SelectionMode == SelectionMode.Single && EqualityComparer.Equals(SelectedItem, item));
}