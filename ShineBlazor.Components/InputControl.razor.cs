using ShineBlazor.Components.Base;

namespace ShineBlazor.Components
{
    /// <summary>
    /// Input editor.
    /// </summary>
    public partial class InputControl<TValue>
    {
        private static readonly Type _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));

        /// <summary>
        /// The input type.
        /// </summary>
        protected InputType InputType => Type.GetTypeCode(_nullableUnderlyingType ?? typeof(TValue)).GetInputType();

        /// <inheritdoc/>
        protected override string ComponentName => "form-control";

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Format ??= InputType.DefaultFormat();
        }
    }
}
