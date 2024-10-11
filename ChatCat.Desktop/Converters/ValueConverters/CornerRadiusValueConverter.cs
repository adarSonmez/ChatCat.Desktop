using ChatCat.Core.Constants.Enums;
using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;
using System.Windows;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts a <see cref="CornerRadius"/> value based on the specified <see cref="CornerType"/>.
    /// </summary>
    public class CornerRadiusValueConverter : BaseValueConverter<CornerRadiusValueConverter>
    {
        /// <summary>
        /// Converts a <see cref="CornerRadius"/> value based on the specified <see cref="CornerType"/>.
        /// </summary>
        /// <param name="value">The <see cref="CornerRadius"/> value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted <see cref="CornerRadius"/> value.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}