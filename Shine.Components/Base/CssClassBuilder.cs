
namespace Shine.Components.Base
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
        /// Adds the border.
        /// </summary>
        /// <param name="edge">The specific component edge border.</param>
        /// <param name="color">Border color</param>
        /// <param name="size">Border size (0-5). Optional.</param>
        /// <param name="radius">The border radius.</param>
        /// <param name="radiusSize">The border radius size (0-5). Optional.</param>
        /// <returns></returns>
        public CssClassBuilder WithBorder(ComponentEdge edge, Color color, uint? size)
        {
            if (edge != ComponentEdge.None)
            {
                _classes.Add("border");

                string cssClass = "border";
                string borderSize = string.Empty;
                if (size.HasValue)
                {
                    size = size > 5 ? 5 : size;
                    borderSize = "-" + size;
                }
                if (edge == ComponentEdge.StartAndEnd)
                {
                    cssClass += $"-top{borderSize} border-bottom{borderSize}";
                }
                else if (edge == ComponentEdge.TopAndBottom)
                {
                    cssClass += $"-start{borderSize} border-end{borderSize}";
                }
                else if (edge != ComponentEdge.All)
                {
                    cssClass += "-" + edge.ToString().ToLowerInvariant() + borderSize;
                }
                _classes.Add(cssClass);

                if (color != Color.None)
                {
                   _classes.Add("border-" + ToString(color));
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
            if (color != Color.None) 
            {
                _classes.Add("text-bg-" + ToString(color));
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
        /// BuildStyles the css.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return JoinClasses(_classes.ToArray());
        }

        /// <summary>
        /// <see cref="Color"/> enum to string color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private string ToString(Color color)
        {
            return color switch
            {
               Color.Body => "body",
               Color.Primary => "primary",
               Color.Secondary => "secondary",
               Color.Info => "info",
               Color.Danger => "danger",
               Color.Warning => "warning",
               Color.Success => "success",
               Color.Light => "light",
               Color.Dark => "dark",
               _ => string.Empty
            };
        }
    }
}
