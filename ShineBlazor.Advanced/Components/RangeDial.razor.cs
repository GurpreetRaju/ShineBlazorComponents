using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShineBlazor.Components.Base;

namespace ShineBlazor.Advanced.Components
{
    /// <summary>
    /// Range dial.
    /// </summary>
    public partial class RangeDial<TValue> : IAsyncDisposable
    {
        private IJSObjectReference _module;
        private IJSObjectReference _dialInstance;

        private ElementReference _wrapper;
        private ElementReference _knob;
        private ElementReference _input;

        /// <inheritdoc/>
        protected override string ComponentName => "range-dial";

        /// <summary>
        /// Dial size.
        /// </summary>
        [Parameter]
        public uint Size { get; set; }

        /// <summary>
        /// JS Runtime.
        /// </summary>
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        /// <inheritdoc/>
        protected override CssStyleBuilder StyleBuilder => base.StyleBuilder
            .AddStyle("--dial-size-px", $"{Size}px", Size > 0)
            .AddStyle("--dial-size", Size.ToString(), Size > 0);

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                _module = await JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/ShineBlazor.Advanced/Components/RangeDial.razor.js");
                _dialInstance = await _module.InvokeAsync<IJSObjectReference>("CreateRangeDial", _wrapper, _knob, _input);
            }
        }

        /// <inheritdoc/>
        protected override async Task Dispose(bool disposing)
        {
            await base.Dispose(disposing);

            if (disposing)
            {
                if (_module != null)
                {
                    await _module.DisposeAsync();
                }
                if (_dialInstance != null)
                {
                    await _dialInstance.DisposeAsync();
                }
            }
        }
    }
}
