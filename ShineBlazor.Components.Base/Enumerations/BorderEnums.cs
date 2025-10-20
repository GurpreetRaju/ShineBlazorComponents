namespace ShineBlazor.Components.Base.Enumerations;

/// <summary>
/// Border.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum Border
{
    /// <summary>
    /// No border.
    /// </summary>
    [StringValue("border-0")]
    None,
    /// <summary>
    /// All edges. Size 1.
    /// </summary>
    [StringValue("border")]
    All_1,
    /// <summary>
    /// All edges. Size 2.
    /// </summary>
    [StringValue("border-2")]
    All_2,
    /// <summary>
    /// All edges. Size 3.
    /// </summary>
    [StringValue("border-3")]
    All_3,
    /// <summary>
    /// All edges. Size 4.
    /// </summary>
    [StringValue("border-4")]
    All_4,
    /// <summary>
    /// All edges. Size 5.
    /// </summary>
    [StringValue("border-5")]
    All_5,
    /// <summary>
    /// Left/Start border. Size 0.
    /// </summary>
    [StringValue("border-start-0")]
    Left_0,
    /// <summary>
    /// Left/Start border. Size 1.
    /// </summary>
    [StringValue("border-start")]
    Left,
    /// <summary>
    /// Left/Start border. Size 2.
    /// </summary>
    [StringValue("border-start-2")]
    Left_2,
    /// <summary>
    /// Left/Start border. Size 3.
    /// </summary>
    [StringValue("border-start-3")]
    Left_3,
    /// <summary>
    /// Left/Start border. Size 4.
    /// </summary>
    [StringValue("border-start-4")]
    Left_4,
    /// <summary>
    /// Left/Start border. Size 5.
    /// </summary>
    [StringValue("border-start-5")]
    Left_5,
    /// <summary>
    /// Top border. Size 0.
    /// </summary>
    [StringValue("border-top-0")]
    Top_0,
    /// <summary>
    /// Top border. Size 1.
    /// </summary>
    [StringValue("border-top")]
    Top,
    /// <summary>
    /// Top border. Size 2.
    /// </summary>
    [StringValue("border-top-2")]
    Top_2,
    /// <summary>
    /// Top border. Size 3.
    /// </summary>
    [StringValue("border-top-3")]
    Top_3,
    /// <summary>
    /// Top border. Size 4.
    /// </summary>
    [StringValue("border-top-4")]
    Top_4,
    /// <summary>
    /// Top border. Size 5.
    /// </summary>
    [StringValue("border-top-5")]
    Top_5,
    /// <summary>
    /// Right/End border. Size 0.
    /// </summary>
    [StringValue("border-right-0")]
    Right_0,
    /// <summary>
    /// Right/End border. Size 1.
    /// </summary>
    [StringValue("border-right")]
    Right,
    /// <summary>
    /// Right/End border. Size 2.
    /// </summary>
    [StringValue("border-right-2")]
    Right_2,
    /// <summary>
    /// Right/End border. Size 3.
    /// </summary>
    [StringValue("border-right-3")]
    Right_3,
    /// <summary>
    /// Right/End border. Size 4.
    /// </summary>
    [StringValue("border-right-4")]
    Right_4,
    /// <summary>
    /// Right/End border. Size 5.
    /// </summary>
    [StringValue("border-right-5")]
    Right_5,
    /// <summary>
    /// Bottom border. Size 0. 
    /// </summary>
    [StringValue("border-bottom-0")]
    Bottom_0,
    /// <summary>
    /// Bottom border. Size 1. 
    /// </summary>
    [StringValue("border-bottom")]
    Bottom,
    /// <summary>
    /// Bottom bottom. Size 2.
    /// </summary>
    [StringValue("border-bottom-2")]
    Bottom_2,
    /// <summary>
    /// Bottom bottom. Size 3.
    /// </summary>
    [StringValue("border-bottom-3")]
    Bottom_3,
    /// <summary>
    /// Bottom bottom. Size 4.
    /// </summary>
    [StringValue("border-bottom-4")]
    Bottom_4,
    /// <summary>
    /// Bottom bottom. Size 5.
    /// </summary>
    [StringValue("border-bottom-5")]
    Bottom_5,
    /// <summary>
    /// Left and right border. Size 0.
    /// </summary>
    [StringValue("border-start-0 border-end-0")]
    StartAndEnd_0,
    /// <summary>
    /// Left and right border. Size 1.
    /// </summary>
    [StringValue("border-start border-end")]
    StartAndEnd,
    /// <summary>
    /// Left and right border. Size 2.
    /// </summary>
    [StringValue("border-start-2 border-end-2")]
    StartAndEnd_2,
    /// <summary>
    /// Left and right border. Size 3.
    /// </summary>
    [StringValue("border-start-3 border-end-3")]
    StartAndEnd_3,
    /// <summary>
    /// Left and right border. Size 4.
    /// </summary>
    [StringValue("border-start-4 border-end-4")]
    StartAndEnd_4,
    /// <summary>
    /// Left and right border. Size 5.
    /// </summary>
    [StringValue("border-start-5 border-end-5")]
    StartAndEnd_5,
    /// <summary>
    /// Top and bottom border. Size 0.
    /// </summary>
    [StringValue("border-top-0 border-bottom-0")]
    TopAndBottom_0,
    /// <summary>
    /// Top and bottom border. Size 1.
    /// </summary>
    [StringValue("border-top border-bottom")]
    TopAndBottom,
    /// <summary>
    /// Top and bottom border. Size 2.
    /// </summary>
    [StringValue("border-top-2 border-bottom-2")]
    TopAndBottom_2,
    /// <summary>
    /// Top and bottom border. Size 3.
    /// </summary>
    [StringValue("border-top-3 border-bottom-3")]
    TopAndBottom_3,
    /// <summary>
    /// Top and bottom border. Size 4.
    /// </summary>
    [StringValue("border-top-4 border-bottom-4")]
    TopAndBottom_4,
    /// <summary>
    /// Top and bottom border. Size 5.
    /// </summary>
    [StringValue("border-top-5 border-bottom-5")]
    TopAndBottom_5,
}

/// <summary>
/// The border radius.
/// </summary>
[ClassNamespace("ShineBlazor.Components")]
internal enum BorderRadius
{
    /// <summary>
    /// No radius.
    /// </summary>
    [StringValue("rounded-0")]
    None,
    /// <summary>
    /// All corners. Size 1.
    /// </summary>
    [StringValue("rounded-1")]
    All,
    /// <summary>
    /// All corners. Size 2.
    /// </summary>
    [StringValue("rounded-2")]
    All_2,
    /// <summary>
    /// All corners. Size 3.
    /// </summary>
    [StringValue("rounded-3")]
    All_3,
    /// <summary>
    /// All corners. Size 4.
    /// </summary>
    [StringValue("rounded-4")]
    All_4,
    /// <summary>
    /// All corners. Size 5.
    /// </summary>
    [StringValue("rounded-5")]
    All_5,
    /// <summary>
    /// All corners. Size Circle.
    /// </summary>
    [StringValue("rounded-circle")]
    All_Circle,
    /// <summary>
    /// All corners. Size Pill.
    /// </summary>
    [StringValue("rounded-pill")]
    All_Pill,
    /// <summary>
    /// Top radius.
    /// </summary>
    [StringValue("rounded-top-0")]
    Top_0,
    /// <summary>
    /// Top corners. Size 1.
    /// </summary>
    [StringValue("rounded-top-1")]
    Top,
    /// <summary>
    /// Top corners. Size 2.
    /// </summary>
    [StringValue("rounded-top-2")]
    Top_2,
    /// <summary>
    /// Top corners. Size 3.
    /// </summary>
    [StringValue("rounded-top-3")]
    Top_3,
    /// <summary>
    /// Top corners. Size 4.
    /// </summary>
    [StringValue("rounded-top-4")]
    Top_4,
    /// <summary>
    /// Top corners. Size 5.
    /// </summary>
    [StringValue("rounded-top-5")]
    Top_5,
    /// <summary>
    /// Top corners. Size Circle.
    /// </summary>
    [StringValue("rounded-top-circle")]
    Top_Circle,
    /// <summary>
    /// Top corners. Size Pill.
    /// </summary>
    [StringValue("rounded-top-pill")]
    Top_Pill,
    /// <summary>
    /// Bottom radius.
    /// </summary>
    [StringValue("rounded-bottom-0")]
    Bottom_0,
    /// <summary>
    /// Bottom corners. Size 1.
    /// </summary>
    [StringValue("rounded-bottom-1")]
    Bottom,
    /// <summary>
    /// Bottom corners. Size 2.
    /// </summary>
    [StringValue("rounded-bottom-2")]
    Bottom_2,
    /// <summary>
    /// Bottom corners. Size 3.
    /// </summary>
    [StringValue("rounded-bottom-3")]
    Bottom_3,
    /// <summary>
    /// Bottom corners. Size 4.
    /// </summary>
    [StringValue("rounded-bottom-4")]
    Bottom_4,
    /// <summary>
    /// Bottom corners. Size 5.
    /// </summary>
    [StringValue("rounded-bottom-5")]
    Bottom_5,
    /// <summary>
    /// Bottom corners. Size Circle.
    /// </summary>
    [StringValue("rounded-bottom-circle")]
    Bottom_Circle,
    /// <summary>
    /// Bottom corners. Size Pill.
    /// </summary>
    [StringValue("rounded-bottom-pill")]
    Bottom_Pill,
    /// <summary>
    /// Start radius.
    /// </summary>
    [StringValue("rounded-start-0")]
    Start_0,
    /// <summary>
    /// Start corners. Size 1.
    /// </summary>
    [StringValue("rounded-start-1")]
    Start,
    /// <summary>
    /// Start corners. Size 2.
    /// </summary>
    [StringValue("rounded-start-2")]
    Start_2,
    /// <summary>
    /// Start corners. Size 3.
    /// </summary>
    [StringValue("rounded-start-3")]
    Start_3,
    /// <summary>
    /// Start corners. Size 4.
    /// </summary>
    [StringValue("rounded-start-4")]
    Start_4,
    /// <summary>
    /// Start corners. Size 5.
    /// </summary>
    [StringValue("rounded-start-5")]
    Start_5,
    /// <summary>
    /// Start corners. Size Circle.
    /// </summary>
    [StringValue("rounded-start-circle")]
    Start_Circle,
    /// <summary>
    /// Start corners. Size Pill.
    /// </summary>
    [StringValue("rounded-start-pill")]
    Start_Pill,
    /// <summary>
    /// End radius.
    /// </summary>
    [StringValue("rounded-end-0")]
    End_0,
    /// <summary>
    /// End corners. Size 1.
    /// </summary>
    [StringValue("rounded-end-1")]
    End,
    /// <summary>
    /// End corners. Size 2.
    /// </summary>
    [StringValue("rounded-end-2")]
    End_2,
    /// <summary>
    /// End corners. Size 3.
    /// </summary>
    [StringValue("rounded-end-3")]
    End_3,
    /// <summary>
    /// End corners. Size 4.
    /// </summary>
    [StringValue("rounded-end-4")]
    End_4,
    /// <summary>
    /// End corners. Size 5.
    /// </summary>
    [StringValue("rounded-end-5")]
    End_5,
    /// <summary>
    /// End corners. Size Circle.
    /// </summary>
    [StringValue("rounded-end-circle")]
    End_Circle,
    /// <summary>
    /// End corners. Size Pill.
    /// </summary>
    [StringValue("rounded-end-pill")]
    End_Pill
}