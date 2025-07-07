using System;
using System.Reflection;
using ShineBlazor.Components.Base;
using Xunit;

namespace ShineBlazor.Components.Tests;

public class CssClassBuilderFlexTests
{
    private static object CreateEnum(string typeName, string value)
    {
        var asm = typeof(CssClassBuilder).Assembly;
        var type = asm.GetType(typeName, throwOnError: true)!;
        return Enum.Parse(type, value);
    }

    private static string BuildFlexClasses(bool row, uint gap, string alignItems, string alignSelf, string alignContent,
        string justifyContent, string wrap, bool flexFill, bool? flexGrow, bool? flexShrink)
    {
        var builder = CssClassBuilder.Create(null);
        var method = typeof(CssClassBuilder).GetMethod("WithFlex")!;
        object alignItemsEnum = CreateEnum("ShineBlazor.Components.Base.Enumerations.FlexAlign", alignItems);
        object alignSelfEnum = CreateEnum("ShineBlazor.Components.Base.Enumerations.FlexAlign", alignSelf);
        object alignContentEnum = CreateEnum("ShineBlazor.Components.Base.Enumerations.FlexContent", alignContent);
        object justifyContentEnum = CreateEnum("ShineBlazor.Components.Base.Enumerations.FlexContent", justifyContent);
        object wrapEnum = CreateEnum("ShineBlazor.Components.Base.Enumerations.FlexWrap", wrap);
        method.Invoke(builder, new object[] { row, gap, alignItemsEnum, alignSelfEnum, alignContentEnum, justifyContentEnum, wrapEnum, flexFill, flexGrow, flexShrink });
        return builder.Build();
    }

    [Fact]
    public void FlexShrink_WithHyphen()
    {
        var classes = BuildFlexClasses(true, 3, "Start", "Start", "Start", "Start", "Wrap", false, null, true);
        Assert.Contains("flex-shrink-1", classes);
    }

    [Fact]
    public void FlexOptions_PopulateClasses()
    {
        var classes = BuildFlexClasses(false, 2, "Center", "Stretch", "Between", "End", "Wrap", true, true, false);
        Assert.Contains("d-flex", classes);
        Assert.Contains("flex-column", classes);
        Assert.Contains("gap-2", classes);
        Assert.Contains("align-content-between", classes);
        Assert.Contains("align-items-center", classes);
        Assert.Contains("align-self-stretch", classes);
        Assert.Contains("justify-content-end", classes);
        Assert.Contains("flex-wrap", classes);
        Assert.Contains("flex-fill", classes);
        Assert.Contains("flex-grow-1", classes);
        Assert.Contains("flex-shrink-0", classes);
    }
}
