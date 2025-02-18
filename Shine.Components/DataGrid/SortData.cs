namespace Shine.Components
{
    /// <summary>
    /// The dorting data.
    /// </summary>
    public class SortData
    {
        /// <summary>
        /// The sort direction.
        /// </summary>
        public SortDirection SortDirection { get; set; }

        /// <summary>
        /// The name of the column to sort by.
        /// </summary>
        public string ColumnName { get; set; }
    }

    /// <summary>
    /// The sort direction.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// No sorting.
        /// </summary>
        None,
        /// <summary>
        /// Ascending.
        /// </summary>
        Ascending,
        /// <summary>
        /// Descending.
        /// </summary>
        Descending
    }
}
