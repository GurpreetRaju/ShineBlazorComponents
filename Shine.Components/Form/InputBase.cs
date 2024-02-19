using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shine.Components;
using System.Linq.Expressions;

namespace Shine.Components.Form
{
    /// <summary>
    /// Provides base functionality for form input components.
    /// </summary>
    public class InputBase<TItem> : ShineComponentBase
    {
        private EditContext m_oldEditContext;
        private FieldIdentifier m_fieldIdentifier;

        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id => Guid.NewGuid();

        /// <summary>
        /// Current edit context.
        /// </summary>
        [CascadingParameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// Label text.
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// Label Content.
        /// </summary>
        [Parameter]
        public RenderFragment LabelContent { get; set; }

        /// <summary>
        /// Whether the input is required.
        /// </summary>
        [Parameter]
        public bool Required { get; set; }

        /// <summary>
        /// Whether the input is read-only.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The selected item.
        /// </summary>
        [Parameter]
        public TItem Value { get; set; }

        /// <summary>
        /// Callback invoked when the <see cref="Value"/> changes.
        /// </summary>
        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        /// <summary>
        /// For expression used for validation message.
        /// </summary>
        [Parameter]
        public Expression<Func<TItem>> For { get; set; }

        /// <summary>
        /// Label column width (between 1-12).
        /// </summary>
        [Parameter]
        public int LabelColWidth { get; set; } = 4;

        /// <summary>
        /// Column break point.
        /// </summary>
        [Parameter]
        public ColumnBreakPoint ColBreakPoint { get; set; }

        /// <summary>
        /// Label column class.
        /// </summary>
        protected string LabelColWidthClass
        {
            get
            {
                if (string.IsNullOrEmpty(Label) && LabelContent == null) return null;

                return $"{ColBreakPoint.ToString().ToLower()}{(LabelColWidth > 12 ? 4 : LabelColWidth)}";
            }
        }

        /// <summary>
        /// Input column class.
        /// </summary>
        protected string InputColWidthClass
        {
            get
            {
                if (string.IsNullOrEmpty(Label) && LabelContent == null) return null;

                return $"{ColBreakPoint.ToString().ToLower()}{(LabelColWidth > 12 ? 8 : 12 - LabelColWidth)}";
            }
        }

        /// <summary>
        /// The validation messages.
        /// </summary>
        protected IEnumerable<string> ValidationMessages 
        {
            get
            {
                if (For == null && EditContext == null) return Enumerable.Empty<string>();

                return EditContext.GetValidationMessages(m_fieldIdentifier);
            }
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (EditContext != null && For != null)
            {
                m_fieldIdentifier = FieldIdentifier.Create(For);
             
                if (EditContext != m_oldEditContext)
                {
                    UnsubscribeValidationStateChangedListener();
                    EditContext.OnValidationStateChanged += OnValidationStateChanged;
                    m_oldEditContext = EditContext;
                }
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            UnsubscribeValidationStateChangedListener();

            base.Dispose(disposing);
        }

        /// <summary>
        /// Unsubscribe the Validation State Changed listener.
        /// </summary>
        private void UnsubscribeValidationStateChangedListener()
        {
            if (m_oldEditContext != null)
            {
                m_oldEditContext.OnValidationStateChanged -= OnValidationStateChanged;
            }
        }

        /// <summary>
        /// Called when the input value is changed. Raises the <see cref="ValueChanged"/>.
        /// </summary>
        protected void OnValueChanged(ChangeEventArgs args)
        {
            Value = (TItem)args.Value;

            if (ValueChanged.HasDelegate)
            {
                ValueChanged.InvokeAsync(Value);
            }
        }

        /// <summary>
        /// Called when the validation state is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ValidationStateChangedEventArgs"/> args.</param>
        private async void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs args)
        {
            await InvokeAsync(StateHasChanged);
        }
    }
}
