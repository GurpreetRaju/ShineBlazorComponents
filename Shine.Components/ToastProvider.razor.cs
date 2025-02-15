using Microsoft.AspNetCore.Components;
using Shine.Components.Services;

namespace Shine.Components
{
    /// <summary>
    /// The toast provider.
    /// </summary>
    public partial class ToastProvider : IDisposable
    {
        /// <summary>
        /// The default toast duration.
        /// </summary>
        public TimeSpan DefaultToastDuration { get; set; }

        /// <summary>
        /// The toast service.
        /// </summary>
        [Inject]
        private ToastService ToastService { get; set; }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            ToastService.ToastsChanged += HandleToastsChanged;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            ToastService.ToastsChanged -= HandleToastsChanged;
        }

        /// <summary>
        /// Handles the <see cref="ToastService.ToastsChanged">.
        /// </summary>
        private void HandleToastsChanged()
        {
            InvokeAsync(StateHasChanged);
        }
    }
}
