using Microsoft.AspNetCore.Components;

namespace Shine.Components
{
    /// <summary>
    /// The data grid column.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public partial class DataGridColumn<TItem, TValue>
    {
        private static readonly SortDirection[] SortOptions = Enum.GetValues<SortDirection>();

        /// <summary>
        /// The expression for data property.
        /// </summary>
        [Parameter]
        public Func<TItem, TValue> DataExpression { get; set; }

        /// <summary>
        /// The template for filter..
        /// </summary>
        [Parameter]
        public RenderFragment<FilterData<TValue>> FilterTemplate { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => "data-grid-column";

        /// <summary>
        /// The filter data.
        /// </summary>
        protected FilterData<TValue> FilterData { get; private set; }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            FilterData = CreateFilterData();
            if (FilterData != null)
            {
                FilterData.FilterChanged += HandleFilterChanged;
            }
        }

        /// <inheritdoc/>
        protected internal override object GetCellValue(TItem item)
        {
            return DataExpression(item);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                FilterData.FilterChanged -= HandleFilterChanged;
            }
        }

        /// <summary>
        /// Creates the filter data.
        /// </summary>
        /// <returns></returns>
        protected virtual FilterData<TValue> CreateFilterData()
        {
            return new FilterData<TValue>
            {
                ColumnName = Name
            };
        }

        /// <summary>
        /// Handles the filter value changes.
        /// </summary>
        private void HandleFilterChanged()
        {
            FilterCriteria = new FilterCriteria(Name, FilterData?.FilterValue);
        }

        /// <summary>
        /// Toggles the sort direction.
        /// </summary>
        private void ToggleSortDirection()
        {
            if (Parent.IsLoading)
                return;

            SortDirection = SortDirection switch 
            { 
                SortDirection.None => SortDirection.Ascending,
                SortDirection.Ascending => SortDirection.Descending,
                SortDirection.Descending => SortDirection.None,
                _ => SortDirection.None,
            };

            OnSortDataChanged();
            InvokeAsync(StateHasChanged);
        }
    }
}
