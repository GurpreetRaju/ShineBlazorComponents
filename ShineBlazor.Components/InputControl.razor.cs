using Microsoft.AspNetCore.Components;
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
        /// Initialize input type.
        /// </summary>
        static InputControl()
        {
            _inputType = Type.GetTypeCode(_nullableUnderlyingType ?? typeof(TValue)).GetInputType();
        }

        /// <summary>
        /// The input type.
        /// </summary>
        protected static InputType _inputType;

        /// <summary>
        /// The label.
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// The placeholder.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// The input variant.
        /// </summary>
        [Parameter]
        public InputVariant Variant { get; set; }

        /// <inheritdoc/>
        protected override string ComponentName => _inputType == InputType.Checkbox ? "form-check-input" : "form-control";

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Format ??= _inputType.DefaultFormat();
        }
    }
}
