using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShineBlazor.Components.Base;

namespace ShineBlazor.Components
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
        /// The progress variant. Default: Color.
        /// </summary>
        [Parameter]
        public ProgressVariant Variant { get; set; } = ProgressVariant.Color;

        /// <summary>
        /// The color for progress circle if variant is <see cref="ProgressVariant.Color"/>. 
        /// Default: <see cref="Color.Primary"/>
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// Show value. Default: true.
        /// </summary>
        [Parameter]
        public bool ShowValue { get; set; } = true;

        /// <summary>
        /// The child content.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// JS Runtime.
        /// </summary>
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        /// <inheritdoc/>
        protected override CssStyleBuilder StyleBuilder => base.StyleBuilder
            .AddStyle("--dial-size-px", $"{Size}px", Size > 0)
            .AddStyle("--dial-size", Size.ToString(), Size > 0)
            .AddStyle("--progress-color", $"var(--bs-{Color})", Variant == ProgressVariant.Color);

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                _module = await JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/ShineBlazor.Components/RangeDial.razor.js");
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
