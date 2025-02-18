namespace Shine.Components
{
    /// <summary>
    /// Data grid items provider delegate.
    /// </summary>
    /// <typeparam name="TItem">The type of item.</typeparam>
    /// <param name="request">The request for fetching items.</param>
    /// <returns></returns>
    public delegate Task<DataResponse<TItem>> DataGridItemsProvider<TItem>(DataRequest request);

    /// <summary>
    /// The data grid items request.
    /// </summary>
    public record DataRequest
    {
        /// <summary>
        /// Page size.
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The filters.
        /// </summary>
        public List<FilterCriteria> Filters { get; set; } = new List<FilterCriteria>();

        /// <summary>
        /// The sort data.
        /// </summary>
        public SortData SortData { get; set; }
    }

    /// <summary>
    /// The response for <see cref="DataRequest"/>.
    /// </summary>
    public record DataResponse<TItem>
    {
        /// <summary>
        /// The list of items.
        /// </summary>
        public List<TItem> Items { get; } = new List<TItem>();

        /// <summary>
        /// The total number of items.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
