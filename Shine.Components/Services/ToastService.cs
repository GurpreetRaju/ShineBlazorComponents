using Shine.Components.Base;

namespace Shine.Components.Services
{
    /// <summary>
    /// The toast service.
    /// </summary>
    public class ToastService
    {
        /// <summary>
        /// The toasts.
        /// </summary>
        public List<ToastInfo> Toasts => new List<ToastInfo>();

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
            Toasts.Add(new ToastInfo { Message = message, Color = color, Title = title, Duration = duration });
            ToastsChanged?.Invoke();
        }

        /// <summary>
        /// Remove the toast.
        /// </summary>
        /// <param name="toast"></param>
        public void RemoveToast(ToastInfo toast)
        {
            Toasts.Remove(toast);
            ToastsChanged?.Invoke();
        }
    }

    /// <summary>
    /// The toast info.
    /// </summary>
    public record ToastInfo
    {
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
    }
}
