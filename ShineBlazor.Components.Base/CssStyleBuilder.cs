namespace ShineBlazor.Components;

/// <summary>
/// BuildStyles style.
/// </summary>
public class CssStyleBuilder
{
    private readonly List<string> _styles = [];

    /// <summary>
    /// Initialize css builder.
    /// </summary>
    private CssStyleBuilder()
    {

    }

    /// <summary>
    /// Create the builder.
    /// </summary>
    /// <returns></returns>
    public static CssStyleBuilder Create()
    {
        return new CssStyleBuilder();
    }

    /// <summary>
    /// Join the styles.
    /// </summary>
    /// <param name="styles"></param>
    /// <returns></returns>
    public static string JoinStyles(params string[] styles)
    {
        return string.Join("; ", styles.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    /// <summary>
    /// Adds the style.
    /// </summary>
    /// <param name="styleName"></param>
    /// <param name="conditionTrueValue"></param>
    /// <param name="conditionFalseValue"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public CssStyleBuilder AddStyle(string styleName, string conditionTrueValue, string conditionFalseValue, bool condition)
    {
        if (!string.IsNullOrWhiteSpace(styleName)) 
        {
            if (condition)
                AddStyle(styleName + ":" + conditionTrueValue);
            else
                AddStyle(styleName + ":" + conditionFalseValue);
        }
        return this;
    }

    /// <summary>
    /// Adds the style.
    /// </summary>
    /// <param name="styleName"></param>
    /// <param name="styleValue"></param>
    /// <returns></returns>
    public CssStyleBuilder AddStyle(string styleName, string styleValue, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(styleName))
        {
            _styles.Add(styleName + ":" + styleValue);
        }
        return this;
    }

    /// <summary>
    /// Adds the style.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    public CssStyleBuilder AddStyle(string style, bool condition = true)
    {
        if (!string.IsNullOrWhiteSpace(style))
        {
            _styles.Add(style);
        }
        return this;
    }

    /// <summary>
    /// Adds the translate value for X axis, duration and timing function for animation. 
    /// The animation 'animate-horizontal' class must be added to the element either manually 
    /// or using <see cref="CssClassBuilder.WithAnimation(Animation)"/>.
    /// </summary>
    /// <param name="transformX">The value (2px, 5rem etc.).</param>
    /// <param name="duration">The duration (0.5s etc.).</param>
    /// <param name="function">The timing function for animation.</param>
    /// <returns></returns>
    public CssStyleBuilder WithHorizontalTransform(string transformX, string duration, AnimationTimingFunction function)
    {
        if (!string.IsNullOrEmpty(transformX))
            _styles.Add($"--sh-animate-value: {transformX}");
        
        if (!string.IsNullOrEmpty(duration))
            _styles.Add($"--sh-animate-duration: {duration}");
        
        if (function != null)
            _styles.Add($"--sh-animate-timing-function: {function}");

        return this;
    }

    /// <summary>
    /// Adds the translate value for Y axis, duration and timing function for animation. 
    /// The animation 'animate-vertical' class must be added to the element either manually or 
    /// using <see cref="CssClassBuilder.WithAnimation(Animation)"/>.
    /// </summary>
    /// <param name="transformY">The value (2px, 5rem etc.).</param>
    /// <param name="duration">The duration (0.5s etc.).</param>
    /// <param name="function">The timing function for animation.</param>
    /// <returns></returns>
    public CssStyleBuilder WithVerticalTransform(string transformY, string duration, AnimationTimingFunction function)
    {
        if (!string.IsNullOrEmpty(transformY))
            _styles.Add($"--sh-animate-value: {transformY}");

        if (!string.IsNullOrEmpty(duration))
            _styles.Add($"--sh-animate-duration: {duration}");

        if (function != null)
            _styles.Add($"--sh-animate-timing-function: {function}");

        return this;
    }

    /// <summary>
    /// Adds the rotation angle value, duration and timing function for animation.
    /// The animation 'animate-rotate' class must be added to the element either manually or 
    /// using <see cref="CssClassBuilder.WithAnimation(Animation)"/>.
    /// </summary>
    /// <param name="angleValue">The angle (25deg).</param>
    /// <param name="duration">The duration (0.5s etc.).</param>
    /// <param name="function">The timing function for animation.</param>
    /// <returns></returns>
    public CssStyleBuilder WithRotateTransform(string angleValue, string duration, AnimationTimingFunction function)
    {
        if (!string.IsNullOrEmpty(angleValue))
            _styles.Add($"--sh-animate-angle-value: {angleValue}");

        if (!string.IsNullOrEmpty(duration))
            _styles.Add($"--sh-animate-duration: {duration}");

        if (function != null)
            _styles.Add($"--sh-animate-timing-function: {function}");

        return this;
    }

    /// <summary>
    /// Adds the X and Y scale value for animation.The animation 'animate-scale' class must be
    /// added to the element either manually or using <see cref="CssClassBuilder.WithAnimation(Animation)"/>.
    /// </summary>
    /// <param name="scaleX">The X value (1.5).</param>
    /// <param name="scaleY">The Y value (1.25).</param>
    /// <param name="duration">The duration (0.5s etc.).</param>
    /// <param name="function">The timing function for animation.</param>
    /// <returns></returns>
    public CssStyleBuilder WithScaleTransform(string scaleX, string scaleY, string duration, AnimationTimingFunction function)
    {
        if (!string.IsNullOrEmpty(scaleX))
            _styles.Add($"--sh-animate-x-value: {scaleX}");

        if (!string.IsNullOrEmpty(scaleY))
            _styles.Add($"--sh-animate-y-value: {scaleY}");

        if (!string.IsNullOrEmpty(duration))
            _styles.Add($"--sh-animate-duration: {duration}");

        if (function != null)
            _styles.Add($"--sh-animate-timing-function: {function}");

        return this;
    }

    /// <summary>
    /// BuildStyles the styles string.
    /// </summary>
    /// <returns></returns>
    public string Build()
    {
        return JoinStyles(_styles.ToArray());
    }
}
