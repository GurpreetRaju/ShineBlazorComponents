using Microsoft.AspNetCore.Components;
using Shine.Components.Base;

namespace Shine.Components
{
    /// <summary>
    /// The pagination component.
    /// </summary>
    public partial class Pagination
    {
        public readonly static int[] PageSizes = [ 10, 15, 25, 50 ];

        private int _startPageNumber = 1;
        private int _endPageNumber = 1;

        /// <summary>
        /// The total number of pages.
        /// </summary>
        [Parameter]
        public int TotalPages { get; set; }

        /// <summary>
        /// The page size.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; }

        /// <summary>
        /// Callback for page size change.
        /// </summary>
        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }

        /// <summary>
        /// The current page number.
        /// </summary>
        [Parameter]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Callback for the current page number change.
        /// </summary>
        [Parameter]
        public EventCallback<int> CurrentPageChanged { get; set; }

        /// <summary>
        /// Items text.
        /// </summary>
        [Parameter]
        public RenderFragment ItemsText { get; set; }

        /// <summary>
        /// Disable next page button.
        /// </summary>
        public bool DisableNextButton => CurrentPage >= TotalPages;
        
        /// <summary>
        /// Disable previous page button.
        /// </summary>
        public bool DisablePrevButton => CurrentPage <= 1;

        /// <inheritdoc/>
        protected override string ComponentName => "pagination";

        /// <inheritdoc/>
        protected override CssClassBuilder CssBuilder => base.CssBuilder.WithClass("mb-0");

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            UpdatePaginationData();
        }

        /// <summary>
        /// Changes the current page number.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        private async Task ChangePageNumber(int pageNumber)
        {
            CurrentPage = pageNumber;
            await CurrentPageChanged.InvokeAsync(pageNumber);

            UpdatePaginationData();
        }

        /// <summary>
        /// Handles the page size changed.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private async Task HandlePageSizeChanged(int pageSize)
        {
            PageSize = pageSize;
            await PageSizeChanged.InvokeAsync(pageSize);

            UpdatePaginationData();
        }

        /// <summary>
        /// Update the pagination data.
        /// </summary>
        private void UpdatePaginationData()
        {
            if (TotalPages > 1)
            {
                if (CurrentPage == 1)
                    _startPageNumber = 1;
                else
                    _startPageNumber = CurrentPage - 1;

                if (CurrentPage == TotalPages)
                    _endPageNumber = TotalPages;
                else
                    _endPageNumber = CurrentPage + 1;
            }
            else
            {
                _startPageNumber = 1;
                _endPageNumber = 1;
            }
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Get css classes for a page item.
        /// </summary>
        /// <param name="disabled"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        private string GetItemClass(bool disabled, bool active)
        {
             return CssClassBuilder.JoinClasses("page-item", disabled ? "disabled" : null, active ? "active" : null);
        }
    }
}
