namespace ShineBlazor.Components
{
    /// <summary>
    /// Data grid items provider delegate.
    /// </summary>
    /// <typeparam name="TItem">The type of item.</typeparam>
    /// <param name="request">The request for fetching items.</param>
    /// <returns></returns>
    public delegate Task<DataResponse<TItem>> DataGridItemsProvider<TItem>(DataRequest request) where TItem : class;

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
        public List<FilterCriteria> Filters { get; } = new List<FilterCriteria>();

        /// <summary>
        /// The sort data.
        /// </summary>
        public SortData? SortData { get; set; }
    }

    /// <summary>
    /// The response for <see cref="DataRequest"/>.
    /// </summary>
    public record DataResponse<TItem>
    {
        /// <summary>
        /// Empty response.
        /// </summary>
        public static DataResponse<TItem> Empty = new DataResponse<TItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataResponse{TItem}"/> class.
        /// </summary>
        public DataResponse()
        {
            Items = new List<TItem>();
            TotalCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataResponse{TItem}"/> class.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        public DataResponse(TItem[] items, int totalCount)
        {
            Items.AddRange(items);
            TotalCount = totalCount;
        }

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
