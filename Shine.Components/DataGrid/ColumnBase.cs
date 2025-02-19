using Microsoft.AspNetCore.Components;
using Shine.Components.Base;

namespace Shine.Components
{
    /// <summary>
    /// The data grid column.
    /// </summary>
    public abstract class ColumnBase<TItem> : ShineComponentBase
    {
        private FilterCriteria _filter;

        /// <summary>
        /// The column Name.
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// The header.
        /// </summary>
        [Parameter]
        public string Header { get; set; }

        /// <summary>
        /// Whether user can sort by this column.
        /// </summary>
        [Parameter]
        public bool CanSort { get; set; }

        /// <summary>
        /// A function to provide css class for a cell.
        /// </summary>
        [Parameter]
        public Func<TItem, string> CellClassFunc { get; set; }

        /// <summary>
        /// The parent data grid.
        /// </summary>
        [CascadingParameter]
        protected DataGrid<TItem> Parent { get; set; }

        /// <summary>
        /// The filter criteria provided by this column.
        /// </summary>
        public FilterCriteria FilterCriteria 
        {
            get => _filter;
            protected set
            {
                if (_filter != value)
                {
                    _filter = value;
                    OnFilterChanged();
                }
            }
        }

        /// <summary>
        /// The sort direction for this column.
        /// </summary>
        public SortDirection SortDirection 
        { 
            get;
            protected set;
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Parent?.AddColumn(this);
        }

        /// <summary>
        /// Reset the sort direction.
        /// </summary>
        internal void ResetSort()
        {
            SortDirection = SortDirection.None;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Renders the cell.
        /// </summary>
        protected internal abstract object GetCellValue(TItem item);

        /// <summary>
        /// Gets the cell css class.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected internal virtual string GetCellClass(TItem item)
        {
            return CellClassFunc == null ? null : CellClassFunc(item);
        }

        /// <summary>
        /// Called when the filter criteria changes.
        /// </summary>
        protected void OnFilterChanged()
        {
            InvokeAsync(StateHasChanged);

            Parent?.ReloadData();
        }

        /// <summary>
        /// Called when the sort data changes.
        /// </summary>
        protected void OnSortDataChanged()
        {
            Parent?.SortDataChanged(Name, SortDirection);
        }
    }
}
