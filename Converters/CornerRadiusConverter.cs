using ChatCat.Desktop.Constants.Enums;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ChatCat.Desktop.Converters
{
    /// <summary>
    /// Converts a <see cref="CornerRadius"/> value based on the specified <see cref="CornerType"/>.
    /// </summary>
    public class CornerRadiusConverter : MarkupExtension, IValueConverter
    {
        /// <<summary>
        /// Converts a <see cref="CornerRadius"/> value based on the specified <see cref="CornerType"/>.
        /// </summary>
        /// <param name="value">The <see cref="CornerRadius"/> value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted <see cref="CornerRadius"/> value.</returns>>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CornerRadius cornerRadius && parameter is CornerType cornerType)
            {
                switch (cornerType)
                {
                    case CornerType.TopLeft:
                        return new CornerRadius(cornerRadius.TopLeft, 0, 0, 0);

                    case CornerType.TopRight:
                        return new CornerRadius(0, cornerRadius.TopRight, 0, 0);

                    case CornerType.BottomLeft:
                        return new CornerRadius(0, 0, cornerRadius.BottomLeft, 0);

                    case CornerType.BottomRight:
                        return new CornerRadius(0, 0, 0, cornerRadius.BottomRight);

                    case CornerType.Bottom:
                        return new CornerRadius(0, 0, cornerRadius.BottomLeft, cornerRadius.BottomRight);

                    case CornerType.Top:
                        return new CornerRadius(cornerRadius.TopLeft, cornerRadius.TopRight, 0, 0);

                    case CornerType.Left:
                        return new CornerRadius(cornerRadius.TopLeft, 0, 0, cornerRadius.BottomLeft);

                    case CornerType.Right:
                        return new CornerRadius(0, cornerRadius.TopRight, cornerRadius.BottomRight, 0);

                    case CornerType.All:
                        return cornerRadius;

                    case CornerType.None:
                        break;

                    default:
                        return new CornerRadius(0, 0, 0, 0);
                }
            }

            return new CornerRadius(0, 0, 0, 0);
        }

        /// <summary>
        /// Converts a <see cref="CornerRadius"/> value back to the original value. This method is not implemented.
        /// </summary>
        /// <param name="value">The <see cref="CornerRadius"/> value to convert back.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted back <see cref="CornerRadius"/> value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Provides a value converter by returning the instance of this converter.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The instance of this converter.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}