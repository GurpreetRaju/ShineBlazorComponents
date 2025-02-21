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
        private SortData _currentSortData;

        private int _pageSize = 10;
        private int _totalPages;
        private int _currentPage = 1;
        private int _totalItems;

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
        /// The striped rows.
        /// </summary>
        [Parameter]
        public bool Striped { get; set; } = true;

        /// <summary>
        /// The bordered table.
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; } = true;

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
            .WithClass("table")
            .WithClass("table-bordered", Bordered)
            .WithClass("table-striped", Striped);

        /// <summary>
        /// The list of columns.
        /// </summary>
        protected List<ColumnBase<TItem>> ColumnDefinitions { get; } = new List<ColumnBase<TItem>>();

        /// <summary>
        /// Whether the data is being loaded.
        /// </summary>
        public bool IsLoading { get; protected set; } = false;

        /// <summary>
        /// Load the data.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await ReloadData();
            }
        }

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
            bool changed = true;
            if (_currentSortData?.ColumnName == columnName)
            {
                if (direction == SortDirection.None)
                    _currentSortData = null;
                else if (direction != _currentSortData.SortDirection)
                    _currentSortData.SortDirection = direction;
                else
                    changed = false;
            }
            else if (direction != SortDirection.None)
            {
                _currentSortData = new SortData { ColumnName = columnName, SortDirection = direction };
            }
            else
            {
                changed = false;
            }

            if (changed)
            {
                ColumnDefinitions.ForEach(c =>
                {
                    if (c.Name != columnName) 
                        c.ResetSort();
                });
                await ReloadData();
            }
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
                _totalItems = 0;

                var result = await ItemsProvider.Invoke(CreateDataRequest());
                if (result != null)
                {
                    CurrentItems.AddRange(result.Items);
                    _totalItems = result.TotalCount;
                }
            }
            finally 
            { 
                _totalPages = _totalItems/_pageSize;
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
                PageSize = _pageSize,
                PageNumber = _currentPage,
                SortData = _currentSortData
            };
            
            request.Filters.AddRange(GetFilters() ?? []);

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

        /// <summary>
        /// Check if the filter criteria is valid.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<FilterCriteria> GetFilters()
        {
            foreach (var column in ColumnDefinitions)
            {
                if (column.FilterCriteria is FilterCriteria { FilterValue : object filterValue } criteria &&
                    (filterValue is not string || filterValue.ToString() != string.Empty))
                {
                    yield return criteria;
                }
            }
        }

        /// <summary>
        /// Handle the page size changes.
        /// </summary>
        protected async Task HandlePageSizeChanged(int pageSize)
        {
            if (_pageSize != pageSize)
            {
                _pageSize = pageSize;

                await ReloadData();
            }
        }

        /// <summary>
        /// Handle the page number changes.
        /// </summary>
        protected async Task HandleCurrentPageChanged(int pageNumber)
        {
            if (_currentPage != pageNumber)
            {
                _currentPage = pageNumber;

                await ReloadData();
            }
        }
    }
}
