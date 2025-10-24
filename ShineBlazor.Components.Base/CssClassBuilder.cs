namespace ShineBlazor.Components;

/// <summary>
/// Css builder.
/// </summary>
public class CssClassBuilder
{
    private readonly List<string> _classes = [];

    /// <summary>
    /// Initialize css builder.
    /// </summary>
    private CssClassBuilder(string mainClass) 
    {
        if (mainClass != null)
            _classes.Add(mainClass);
    }

    /// <summary>
    /// Create the builder.
    /// </summary>
    /// <param name="componentClass"></param>
    /// <returns></returns>
    public static CssClassBuilder Create(string componentClass)
    {
        return new CssClassBuilder(componentClass);
    }

    /// <summary>
    /// Joins the css class names.
    /// </summary>
    /// <param name="classes"></param>
    /// <returns></returns>
    public static string JoinClasses(params string[] classes)
    {
        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    /// <summary>
    /// Joins the css class names.
    /// </summary>
    /// <param name="classes"></param>
    /// <returns></returns>
    public static string JoinClasses(IEnumerable<string> classes)
    {
        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    /// <summary>
    /// Adds the css class.
    /// </summary>
    /// <param name="classNames">The class to add.</param>
    /// <param name="condition">The condition.</param>
    /// <returns></returns>
    public CssClassBuilder WithClass(string classNames, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(classNames))
        {
            _classes.Add(classNames);
        }
        return this;
    }

    /// <summary>
    /// Adds the css class.
    /// </summary>
    /// <param name="classFunc">The function that provides the class to add.</param>
    /// <param name="condition">The condition.</param>
    /// <returns></returns>
    public CssClassBuilder WithClass(Func<string> classFunc, bool condition = true)
    {
        if (condition && classFunc != null)
        {
            _classes.Add(classFunc());
        }
        return this;
    }

    /// <summary>
    /// Adds the border.
    /// </summary>
    /// <param name="edge">The specific component edge border.</param>
    /// <param name="color">Border color</param>
    /// <param name="size">Border size (0-5). Optional.</param>
    /// <returns></returns>
    public CssClassBuilder WithBorder(Border border, Color color)
    {
        if (border != null && border != Border.Default)
        {
            _classes.Add(border);

            if (color != null)
               _classes.Add("border-" + color);
        }

        return this;
    }

    /// <summary>
    /// Adds the border radius.
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    public CssClassBuilder WithBorderRadius(BorderRadius radius)
    {
        if (radius != null && radius != BorderRadius.Default)
        {
            _classes.Add(radius);
        }
        return this;
    }

    /// <summary>
    /// Adds the background color class.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public CssClassBuilder WithBackground(Color color)
    {
        if (color != null) 
        {
            _classes.Add("text-bg-" + color);
        }
        return this;
    }

    /// <summary>
    /// Adds the text color class.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public CssClassBuilder WithTextColor(Color color)
    {
        if (color != null) 
        {
            _classes.Add("text-" + color);
        }
        return this;
    }

    /// <summary>
    /// Adds the text css.
    /// </summary>
    /// <param name="alignment">The text alignment.</param>
    /// <param name="viewportSize">The viewport size.</param>
    /// <param name="textWrap">The text textWrap.</param>
    /// <param name="textTransform">The text textTransform.</param>
    /// <returns></returns>
    public CssClassBuilder WithText(Alignment alignment, ViewportSize viewportSize, TextWrap textWrap, 
        TextTransform textTransform)
    {
        if (alignment != null && alignment != Alignment.Default)
        {
            string textAlign = "text-";
            if (viewportSize != null)
            {
                textAlign += viewportSize + "-";
            }
            textAlign += alignment;

            _classes.Add(textAlign);
        }

        if (textWrap != null || textWrap != TextWrap.Default)
            _classes.Add(textWrap);

        if (textTransform != null && textTransform != TextTransform.Default)
            _classes.Add(textTransform);
        
        return this;
    }

    /// <summary>
    /// Adds the shadow css.
    /// </summary>
    /// <param name="shadow">The shadow.</param>
    /// <returns></returns>
    public CssClassBuilder WithShadow(Shadow shadow)
    {
        if (shadow != null)
            _classes.Add(shadow);

        return this;
    }

    /// <summary>
    /// Adds the flex css.
    /// </summary>
    /// <returns></returns>
    public CssClassBuilder WithFlex(bool row, FlexGap gap, FlexAlignSelf flexAlignSelf, FlexAlign flexAlign,
        FlexJustify justifyContent, FlexWrap wrap, bool flexFill, bool? flexGrow, bool? flexShrink)
    {
            _classes.Add("d-flex");

            if (row)
                _classes.Add("flex-row");
            else
                _classes.Add("flex-column");

            if (gap != null && gap != FlexGap.Default)
                _classes.Add(gap);

            if (flexAlign != null && flexAlign != FlexAlign.Default)
                _classes.Add(flexAlign);

            if (flexAlignSelf != null && flexAlignSelf != FlexAlignSelf.Default)
                _classes.Add(flexAlignSelf);

            if (justifyContent != null && justifyContent != FlexJustify.Default)
                _classes.Add(justifyContent);
            
            if (wrap != null && wrap != FlexWrap.Default)
                _classes.Add(wrap);

            if (flexFill)
                _classes.Add("flex-fill");

            if (flexGrow.HasValue)
                _classes.Add($"flex-grow-{(flexGrow.Value ? "1" : "0")}");

            if (flexShrink.HasValue)
                _classes.Add($"flex-shrink-{(flexShrink.Value ? "1" : "0")}");

        return this;
    }

    /// <summary>
    /// Adds the animate css class.
    /// </summary>
    /// <returns></returns>
    public CssClassBuilder WithAnimation(Animation animation)
    {
        if (animation != Animation.Default)
            _classes.Add(animation);

        return this;
    }

    /// <summary>
    /// Builds the css.
    /// </summary>
    /// <returns></returns>
    public string Build() => JoinClasses(_classes);
}
