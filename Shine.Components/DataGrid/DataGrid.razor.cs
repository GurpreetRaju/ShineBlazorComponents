using Microsoft.AspNetCore.Components;
using Shine.Components.Base;

namespace Shine.Components
{
    /// <summary>
    /// The data grid.
    /// </summary>
    public partial class DataGrid<TItem>
    {
        private readonly List<TItem> _currentItems = new List<TItem>();

        /// <summary>
        /// Items provider.
        /// </summary>
        [Parameter]
        public DataGridItemsProvider<TItem> ItemsProvider { get; set; }

        /// <summary>
        /// The column definitions.
        /// </summary>
        [Parameter]
        public RenderFragment Columns { get; set; }

        /// <summary>
        /// The function to provide css class for a row.
        /// </summary>
        [Parameter]
        public Func<TItem, string> RowClassFunc { get; set; }

        /// <summary>
        /// The template to display for no items.
        /// </summary>
        [Parameter]
        public RenderFragment NoItemTemplate { get; set; }

        /// <summary>
        /// The current items.
        /// </summary>
        public List<TItem> CurrentItems => _currentItems;

        /// <inheritdoc/>
        protected override string ComponentName => "data-grid";

        /// <inheritdoc/>
        protected override CssClassBuilder CssBuilder => base.CssBuilder
            .WithClass("table");

        /// <summary>
        /// The list of columns.
        /// </summary>
        protected List<ColumnBase<TItem>> ColumnDefinitions { get; } = new List<ColumnBase<TItem>>();

        /// <summary>
        /// Whether the data is being loaded.
        /// </summary>
        protected bool IsLoading { get; set; } = false;

        /// <summary>
        /// Load the data.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ReloadData();
        }

        /// <summary>
        /// The total items.
        /// </summary>
        protected int TotalItems { get; private set; }

        /// <summary>
        /// Add column.
        /// </summary>
        /// <param name="column"></param>
        internal void AddColumn(ColumnBase<TItem> column)
        {
            ColumnDefinitions.Add(column);
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="column"></param>
        internal void RemoveColumn(ColumnBase<TItem> column)
        {
            ColumnDefinitions.Remove(column);
        }

        /// <summary>
        /// Called when  the sort direction changes for a column.
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="direction"></param>
        internal async void SortDataChanged(string columnName, SortDirection direction)
        {
            await ReloadData();
        }

        /// <summary>
        /// Reload data.
        /// </summary>
        internal async Task ReloadData()
        {
            if (ItemsProvider == null || IsLoading)
                return;

            try
            {
                IsLoading = true;
                await InvokeAsync(StateHasChanged);

                CurrentItems.Clear();
                TotalItems = 0;

                var result = await ItemsProvider.Invoke(CreateDataRequest());
                if (result != null)
                {
                    CurrentItems.AddRange(result.Items);
                    TotalItems = result.TotalCount;
                }
            }
            finally 
            { 
                IsLoading = false;
                await InvokeAsync(StateHasChanged);
            }
        }

        /// <summary>
        /// Creates data request.
        /// </summary>
        /// <returns></returns>
        protected virtual DataRequest CreateDataRequest()
        {
            var request = new DataRequest
            {
                //PageSize = PageSize,
                //PageNumber = CurrentPage
                //SortData = _currentSortData
            };

            return request;
        }

        /// <summary>
        /// Gets the row class.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual string GetRowClass(TItem item)
        {
            return RowClassFunc == null ? null : RowClassFunc(item);
        }
    }
}
