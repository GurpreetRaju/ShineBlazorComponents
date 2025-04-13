using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShineBlazor.Components.Services;
using System.Text;

namespace ShineBlazor.Components.Theme
{
    /// <summary>
    /// Theme selector.
    /// </summary>
    public partial class ThemeSelector
    {
        private const string DarkModeName = "dark";
        private const string LightModeName = "light";

        /// <summary>
        /// The current theme.
        /// </summary>
        [Parameter]
        public ThemeBase Theme { get; set; } = new DefaultTheme();

        /// <summary>
        /// Whether to show button to switch mode.
        /// </summary>
        [Parameter]
        public bool ShowThemeSwitch { get; set; } = true;

        /// <summary>
        /// Color of switch mode button.
        /// </summary>
        [Parameter]
        public Color SwitchColor { get; set; } = Color.Light;

        /// <summary>
        /// Whether to use dark palette.
        /// </summary>
        [Parameter]
        public bool DarkMode { get; set; }

        /// <summary>
        /// Event callback for mode changes.
        /// </summary>
        [Parameter]
        public EventCallback<bool> DarkModeChanged { get; set; }

        /// <summary>
        /// Adds the theme styles to head. Default: true.
        /// </summary>
        [Parameter]
        public bool HeadOutlet { get; set; } = true; 

        /// <summary>
        /// Js runtime.
        /// </summary>
        [Inject]
        private IJSRuntime JSRuntime { get; set; } 

        /// <summary>
        /// The toast service.
        /// </summary>
        [Inject]
        private ToastService ToastService { get; set; }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                await base.OnAfterRenderAsync(firstRender);

                if (JSRuntime != null)
                {
                    await JSRuntime.InvokeVoidAsync("setHtmlAttribute", "data-bs-theme", DarkMode ? DarkModeName : LightModeName);
                }
            }
            catch (Exception ex) 
            {
                ToastService.AddToast($"Failed to load: {ex}", Color.Danger);
            }
        }

        /// <summary>
        /// BuildStyles the theme.
        /// </summary>
        private string Build()
        {
            if (Theme == null)
                return string.Empty;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<style class='theme-provider'>");
            stringBuilder.Append(":root,");
            if (DarkMode)
                stringBuilder.Append($" [data-bs-theme={DarkModeName}]");
            else
                stringBuilder.Append($" [data-bs-theme={LightModeName}]");

            stringBuilder.AppendLine("{");

            Theme.BuildStyles(stringBuilder, DarkMode);

            stringBuilder.AppendLine("}");
            stringBuilder.AppendLine("</style>");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Toggle mode.
        /// </summary>
        private void Toggle()
        {
            DarkMode = !DarkMode;
            DarkModeChanged.InvokeAsync(DarkMode);

            InvokeAsync(StateHasChanged);
        }
    }
}
