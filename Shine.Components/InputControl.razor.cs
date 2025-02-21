using Shine.Components.Common;

namespace Shine.Components
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
        protected InputType InputType
        {
            get
            {
                var typeCode = Type.GetTypeCode(_nullableUnderlyingType ?? typeof(TValue));

                switch (typeCode)
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        return InputType.Number;
                    case TypeCode.DateTime:
                        return InputType.DateTime;
                };
                return InputType.Text;
            }
        }

        /// <inheritdoc/>
        protected override string ComponentName => "form-control";

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Format ??= DefaultFormat(InputType);
        }
    }
}
