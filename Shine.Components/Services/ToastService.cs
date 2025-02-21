using Microsoft.Extensions.Configuration;
using Shine.Components.Base;

namespace Shine.Components.Services
{
    /// <summary>
    /// The toast service.
    /// </summary>
    public class ToastService
    {
        /// <summary>
        /// The default toast duration. Default: 5 seconds.
        /// </summary>
        private TimeSpan _defaultToastDuration = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Initialize the toast service.
        /// </summary>
        public ToastService(IConfiguration configuration) 
        {
            var duration = configuration.GetSection("ToastDuration")?.Value;
            if (duration != null && int.TryParse(duration, out int toastDuration))
            {
                _defaultToastDuration = TimeSpan.FromSeconds(toastDuration);
            }
        }

        /// <summary>
        /// The toasts.
        /// </summary>
        public List<ToastInfo> Toasts { get; } = new List<ToastInfo>();

        /// <summary>
        /// Event raised when a toast is added/removed.
        /// </summary>
        public event Action ToastsChanged;

        /// <summary>
        /// Adds the toast.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="color">The toast color.</param>
        /// <param name="title">The title for toast. Optional.</param>
        public void AddToast (string message, Color? color, string title = null, TimeSpan? duration = null)
        {
            Toasts.Add(new ToastInfo { Message = message, Color = color, Title = title, Duration = duration ?? _defaultToastDuration });
            ToastsChanged?.Invoke();
        }

        /// <summary>
        /// Remove the toast.
        /// </summary>
        /// <param name="toast"></param>
        public void RemoveToast(ToastInfo toast)
        {
            if (toast == null)
                return;

            Toasts.Remove(toast);
            ToastsChanged?.Invoke();

            toast.Dispose();
        }
    }

    /// <summary>
    /// The toast info.
    /// </summary>
    public class ToastInfo : IDisposable
    {
        private Timer _timer;

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The color.
        /// </summary>
        public Color? Color { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The duration.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Sart timer if not already.
        /// </summary>
        public void StartTimer(Action<ToastInfo> timerElapsed)
        {
            if (_timer != null || !Duration.HasValue)
                return;

            _timer = new Timer((x) => timerElapsed?.Invoke(this), null, Duration.Value, Timeout.InfiniteTimeSpan);
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
            _timer = null;
        }
    }
}
