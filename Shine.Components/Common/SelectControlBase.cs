using Microsoft.AspNetCore.Components;
using Shine.Components.Base;

namespace Shine.Components.Common
{
    /// <summary>
    /// Provides base functionality for select control.
    /// </summary>
    public abstract class SelectControlBase<TItem> : ShineComponentBase
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
        /// Item to text.
        /// </summary>
        [Parameter]
        public Func<TItem, string> ItemToText { get; set; }

        /// <summary>
        /// Item clicked callback.
        /// </summary>
        [Parameter]
        public EventCallback<TItem> ItemClicked { get; set; }

        /// <summary>
        /// Item Template.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// The trigger content.
        /// </summary>
        [Parameter]
        public RenderFragment TriggerContent { get; set; }

        /// <summary>
        /// The trigger class.
        /// </summary>
        [Parameter]
        public string TriggerClass { get; set; }

        /// <summary>
        /// The drop down class.
        /// </summary>
        [Parameter]
        public string DropDownClass { get; set; }

        /// <summary>
        /// The equality comparer.
        /// </summary>
        [Parameter]
        public IEqualityComparer<TItem> EqualityComparer { get; set; }

        /// <summary>
        /// Open the drop down.
        /// </summary>
        protected bool Open { get; set; }

        /// <summary>
        /// The main class for the drop down container.
        /// </summary>
        protected virtual string DropDownContainerClass => "dropdown-menu";

        /// <summary>
        /// The compiled css classes for drop down.
        /// </summary>
        protected string DropDownClasses => CssClassBuilder.JoinClasses(DropDownContainerClass, DropDownClass, Open ? "show" : null);

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            EqualityComparer ??= EqualityComparer<TItem>.Default;
        }

        /// <summary>
        /// Get the text to show for a item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual string GetDisplayText(TItem item) => ItemToText == null || item == null ? item?.ToString() : ItemToText(item);
        
        /// <summary>
        /// Get the text to show for a item.
        /// </summary>
        /// <returns></returns>
        protected string GetSelectedItemtext()
        {
            if (SelectionMode == SelectionMode.Single)
            {
                return GetDisplayText(SelectedItem);
            }
            else if (SelectedItems != null)
            {
                return string.Join("; ", SelectedItems.Select(GetDisplayText));
            }
            return string.Empty;
        }
        
        /// <summary>
        /// Get the css classes for a item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual IEnumerable<string> GetItemClasses(TItem item)
        {
            yield return "dropdown-item";

            if (SelectionMode == SelectionMode.Single && Equals(SelectedItem, item))
            {
                yield return "active";
            }
            else if (SelectionMode == SelectionMode.Multiple && SelectedItems?.Contains(item) == true)
            {
                yield return "active";
            }
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
            Close();
        }

        /// <summary>
        /// Toggle the drop down.
        /// </summary>
        protected void Toggle()
        {
            Open = !Open;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Close the drop down.
        /// </summary>
        protected void Close()
        {
            Open = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
