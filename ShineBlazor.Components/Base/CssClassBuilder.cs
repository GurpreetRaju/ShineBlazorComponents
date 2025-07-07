
namespace ShineBlazor.Components.Base
{
    /// <summary>
    /// Css builder.
    /// </summary>
    public class CssClassBuilder
    {
        private readonly List<string> _classes = new List<string>();

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
        /// <param name="radius">The border radius.</param>
        /// <param name="radiusSize">The border radius size (0-5). Optional.</param>
        /// <returns></returns>
        public CssClassBuilder WithBorder(BorderEdge edge, Color color, uint? size)
        {
            if (edge != BorderEdge.None)
            {
                string cssClass;
                string borderSize = string.Empty;
                if (size.HasValue)
                {
                    size = size > 5 ? 5 : size;
                    borderSize = "-" + size;
                }
                if (edge == BorderEdge.TopAndBottom)
                {
                    cssClass = $"border-top{borderSize} border-bottom{borderSize}";
                }
                else if (edge == BorderEdge.StartAndEnd)
                {
                    cssClass = $"border-start{borderSize} border-end{borderSize}";
                }
                else if (edge != BorderEdge.All)
                {
                    cssClass = "border-" + edge.ToString().ToLowerInvariant() + borderSize;
                }
                else
                {
                    cssClass = "border" + borderSize;
                }
                _classes.Add(cssClass);

                if (color != null)
                {
                   _classes.Add("border-" + color);
                }
            }

            return this;
        }

        /// <summary>
        /// Adds the border radius.
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="radiusSize"></param>
        /// <returns></returns>
        public CssClassBuilder WithBorderRadius(BorderRadius radius, uint? radiusSize)
        {
            if (radius != BorderRadius.None)
            {
                string radiusClass = "rounded";
                if (radius != BorderRadius.Standard)
                {
                    radiusClass += "-" + radius.ToString().ToLowerInvariant();
                }
                if (radiusSize.HasValue)
                {
                    radiusSize = radiusSize > 5 ? 5 : radiusSize;
                    radiusClass += "-" + radiusSize;
                }
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
        /// Adds the text css.
        /// </summary>
        /// <param name="alignment">The text alignment.</param>
        /// <param name="viewportSize">The viewport size.</param>
        /// <param name="wrap">The text wrap.</param>
        /// <param name="transform">The text transform.</param>
        /// <returns></returns>
        public CssClassBuilder WithText(Alignment alignment, ViewportSize? viewportSize, Wrap wrap, Transform transform)
        {
            if (alignment != Alignment.None)
            {
                string textAlign = "text-";
                if (viewportSize.HasValue)
                {
                    textAlign += viewportSize.ToString().ToLowerInvariant() + "-";
                }
                textAlign += alignment.ToString().ToLowerInvariant();

                _classes.Add(textAlign);
            }

            if (wrap != Wrap.None)
            {
                _classes.Add("text-" + wrap.ToString().ToLowerInvariant());
            }

            if (transform != Transform.None)
            {
                _classes.Add("text-" + transform.ToString().ToLowerInvariant());
            }

            return this;
        }

        /// <summary>
        /// Adds the shadow css.
        /// </summary>
        /// <param name="shadow">The shadow.</param>
        /// <returns></returns>
        public CssClassBuilder WithShadow(Shadow? shadow)
        {
            if (shadow.HasValue)
            {
                string shadowClass = "shadow";
                if (shadow != Shadow.Md)
                    shadowClass += "-" + shadow.ToString().ToLowerInvariant();

                _classes.Add(shadowClass);
            }

            return this;
        }

        /// <summary>
        /// Adds the flex css.
        /// </summary>
        /// <returns></returns>
        public CssClassBuilder WithFlex(bool row, uint gap, FlexAlign alignItems, FlexAlign alignSelf, 
            FlexContent alignContent, FlexContent justifyContent, FlexWrap wrap, bool flexFill, 
            bool? flexGrow, bool? flexShrink)
        {
                _classes.Add("d-flex");

                if (row)
                    _classes.Add("flex-row");
                else
                    _classes.Add("flex-column");

                _classes.Add($"gap-{gap}");

                if (alignContent != null)
                    _classes.Add($"align-content-{alignContent}");

                if (alignItems != null)
                    _classes.Add($"align-items-{alignItems}");

                if (alignSelf != null)
                    _classes.Add($"align-self-{alignSelf}");

                if (justifyContent != null)
                    _classes.Add($"justify-content-{justifyContent}");
                
                if (wrap != null)
                    _classes.Add($"flex-{wrap}");

                if (flexFill)
                    _classes.Add("flex-fill");

                if (flexGrow.HasValue)
                    _classes.Add($"flex-grow-{(flexGrow.Value ? "1" : "0")}");

                if (flexShrink.HasValue)
                    _classes.Add($"flex-shrink-{(flexShrink.Value ? "1" : "0")}");

            return this;
        }

        /// <summary>
        /// Builds the css.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            var classs = JoinClasses(_classes.ToArray());

            return classs;
        }
    }
}
