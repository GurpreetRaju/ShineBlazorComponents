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
                ColumnName = ColumnName
            };
        }

        /// <summary>
        /// Handles the filter value changes.
        /// </summary>
        private void HandleFilterChanged()
        {
            FilterCriteria = new FilterCriteria(ColumnName, FilterData?.FilterValue);
        }

        /// <summary>
        /// Handles the sort direction changes.
        /// </summary>
        private void HandleSortChanged(SortDirection direction)
        {
            SortDirection = direction;
        }
    }
}
