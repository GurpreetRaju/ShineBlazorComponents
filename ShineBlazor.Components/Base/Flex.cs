namespace ShineBlazor.Components
{
    /// <summary>
    /// Flex properties.
    /// </summary>
    public record Flex
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Flex(bool row, ushort gap, AlignItems align, AlignContent justify, 
            AlignItems self = null, AlignContent alignContent = null, bool? grow = null, 
            bool? shrink = null, bool fill = false)
        {
            Row = row;
            Gap = gap;
            AlignItems = align;
            AlignSelf = self;
            AlignContent = alignContent;
            JustifyContent = justify;
            FlexGrow = grow;
            FlexShrink = shrink;
            FlexFill = fill;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Flex() { }

        /// <summary>
        /// Row if true otherwise column.
        /// </summary>
        public bool Row { get; set; }

        /// <summary>
        /// Gap (0-5).
        /// </summary>
        public ushort Gap { get; set; }

        /// <summary>
        /// Align items.
        /// </summary>
        public AlignItems AlignItems { get; set; }

        /// <summary>
        /// Justify content.
        /// </summary>
        public AlignItems AlignSelf { get; set; }

        /// <summary>
        /// Align Content.
        /// </summary>
        public AlignContent AlignContent { get; set; }

        /// <summary>
        /// Justify content.
        /// </summary>
        public AlignContent JustifyContent { get; set; }

        /// <summary>
        /// Flex wrap.
        /// </summary>
        public FlexWrap Wrap { get; set; }

        /// <summary>
        /// Flex fill.
        /// </summary>
        public bool FlexFill { get; set; }

        /// <summary>
        /// Flex grow.
        /// </summary>
        public bool? FlexGrow { get; set; }

        /// <summary>
        /// Flex shrink.
        /// </summary>
        public bool? FlexShrink { get; set; }
    }

    /// <summary>
    /// Flex Align.
    /// </summary>
    public class AlignItems
    {
        private string _text;
        private AlignItems(string text) { _text = text; }
        public static AlignItems Start => new("start");
        public static AlignItems End => new("end");
        public static AlignItems Center => new("center");
        public static AlignItems Stretch => new("stretch");
        public static AlignItems Baseline => new("baseline");
        public override string ToString() => _text;
    }

    /// <summary>
    /// Align Content.
    /// </summary>
    public class AlignContent
    {
        private string _text;
        private AlignContent(string text) { _text = text; }
        public static AlignContent Start => new("start");
        public static AlignContent End => new("end");
        public static AlignContent Center => new("center");
        public static AlignContent Between => new("between");
        public static AlignContent Around => new("around");
        public static AlignContent Evenly => new("evenly");
        public override string ToString() => _text;
    }

    /// <summary>
    /// Flex Wrap.
    /// </summary>
    public class FlexWrap
    {
        private string _text;
        private FlexWrap (string text) { _text = text; }
        public static FlexWrap NoWrap => new("nowrap"); 
        public static FlexWrap Wrap => new("wrap"); 
        public static FlexWrap WrapReverse => new("wrap-reverse");
        public override string ToString() => _text;
    }
}
