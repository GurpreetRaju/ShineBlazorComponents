namespace Shine.Components
{
    /// <summary>
    /// The filter.
    /// </summary>
    public record FilterCriteria
    {
        /// <summary>
        /// The filter criteria.
        /// </summary>
        public FilterCriteria(string columnName, object value) 
        {
            ColumnName = columnName;
            FilterValue = value;
        }

        /// <summary>
        /// The column name.
        /// </summary>
        public string ColumnName { get; init; }

        /// <summary>
        /// The filter value.
        /// </summary>
        public object FilterValue { get; init; }
    }

    /// <summary>
    /// The filter data.
    /// </summary>
    public class FilterData<TValue>
    {
        private TValue _value;
        private EqualityComparer<TValue> _comparer;

        /// <summary>
        /// Initializes the filter data.
        /// </summary>
        /// <param name="comparer"></param>
        public FilterData(EqualityComparer<TValue> comparer = null)
        {
            _comparer = comparer ?? EqualityComparer<TValue>.Default;
        }

        /// <summary>
        /// The column name.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// The filter value.
        /// </summary>
        public TValue Value 
        {
            get => _value;
            set
            {
                if (!_comparer.Equals(_value, value))
                {
                    _value = value;
                    FilterChanged?.Invoke();
                }
            }
        }

        /// <summary>
        /// The filter value.
        /// </summary>
        public object FilterValue => Value;

        /// <summary>
        /// The filter type.
        /// </summary>
        public Type FilterType => typeof(TValue);

        /// <summary>
        /// Event raised when filter value changes.
        /// </summary>
        public event Action FilterChanged;
    }
}
