using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ShineBlazor.Components
{
    /// <summary>
    /// The delegate for loading items for infinite scroll view.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="request">The request to load items.</param>
    /// <returns>The response containing the items.</returns>
    public delegate Task<InfiniteScrollItemsResponse<TItem>> InfiniteScrollItemsProvider<TItem>(InfiniteScrollItemsRequest request); 

    /// <summary>
    /// Provides infinite scrolling.
    /// </summary>
    public partial class InfiniteScroll<TItem>
    {
        /// <summary>
        /// The current items.
        /// </summary>
        protected readonly List<TItem> _currentItems = new List<TItem>();

        private readonly object _lock = new();
        private string _error;
        private int _totalItems = 0;
        private bool _loadingItems;
        private bool _haveMoreItems = true;
        private bool _initialized = false;

        private ElementReference _lastItemIndicator;
        private IJSObjectReference _module;
        private IJSObjectReference _instance;
        private DotNetObjectReference<InfiniteScroll<TItem>> _currentComponentReference;

        /// <summary>
        /// The function to load items.
        /// </summary>
        [Parameter]
        public InfiniteScrollItemsProvider<TItem> ItemsProvider { get; set; }

        /// <summary>
        /// The page size. Default: 12.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 12;

        /// <summary>
        /// Callback for handling errors.
        /// </summary>
        [Parameter]
        public EventCallback<Exception> ErrorHandler { get; set; }

        /// <summary>
        /// The item template.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// Callback for items count change.
        /// </summary>
        [Parameter]
        public EventCallback<int> ItemsCountChanged { get; set; }

        /// <summary>
        /// JS Runtime.
        /// </summary>
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => "infinite-scroll";

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await LoadItems();
            }
        }

        /// <summary>
        /// Load items.
        /// </summary>
        /// <returns></returns>
        [JSInvokable]
        public async Task LoadItems()
        {
            try
            {
                if (!TryLoadingItems())
                    return;

                Console.WriteLine($"Loading Items......{DateTime.Now.ToString("G")}");

                _error = null;

                var response = await ItemsProvider.Invoke(new InfiniteScrollItemsRequest
                {
                    PageSize = PageSize,
                    SkipCount = _currentItems.Count
                });

                if (response?.Items != null)
                {
                    _currentItems.AddRange(response.Items);
                    _totalItems = response.TotalItems;

                    RaiseItemsCountChanged();
                }

                _haveMoreItems = _currentItems.Count < _totalItems;
                if (_haveMoreItems)
                {
                    if (_initialized)
                    {
                        await _instance.InvokeVoidAsync("itemsLoaded");
                    }
                    else
                    {
                        await Initialize();
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;

                if (ErrorHandler.HasDelegate)
                {
                    await ErrorHandler.InvokeAsync(ex);
                }
            }
            finally
            {
                _loadingItems = false;
            }

            await InvokeAsync(StateHasChanged);
        }

        /// <inheritdoc/>
        protected override async Task Dispose(bool disposing)
        {
            await base.Dispose(disposing);

            if (disposing)
            {
                if (_instance != null)
                {
                    await _instance.InvokeVoidAsync("dispose");
                    await _instance.DisposeAsync();
                    _instance = null;
                }

                if (_module != null)
                {
                    await _module.DisposeAsync();
                }

                _currentComponentReference?.Dispose();
            }
        }

        /// <summary>
        /// Initialize the last item indicator observer.
        /// </summary>
        private async Task Initialize()
        {
            _module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/ShineBlazor.Components/InfiniteScroll.razor.js");

            _currentComponentReference = DotNetObjectReference.Create(this);
            _instance = await _module.InvokeAsync<IJSObjectReference>("initialize", _lastItemIndicator, _currentComponentReference);

            _initialized = true;
        }

        /// <summary>
        /// Determine whether the items can be loaded. If so,
        /// set <see cref="_loadingItems"/> to true and returns true, otherwise false.
        /// </summary>
        /// <returns></returns>
        private bool TryLoadingItems()
        {
            lock (_lock)
            {
                if (_loadingItems)
                    return false;

                _loadingItems = true;

                return _loadingItems;
            }
        }

        /// <summary>
        /// Raise items count changed.
        /// </summary>
        private void RaiseItemsCountChanged()
        {
            ItemsCountChanged.InvokeAsync(_currentItems.Count);
        }
    }

    /// <summary>
    /// The request to get items for infinite scrolling.
    /// </summary>
    public class InfiniteScrollItemsRequest
    {
        /// <summary>
        /// The page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The skip count.
        /// </summary>
        public int SkipCount { get; set; }
    }

    /// <summary>
    /// The response for the <see cref="InfiniteScrollItemsRequest"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InfiniteScrollItemsResponse<T> 
    { 
        /// <summary>
        /// The total number of items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Items.
        /// </summary>
        public T[] Items { get; set; }
    }
}
