using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;
using System.Windows.Media;

namespace ChatCat.Desktop.Converters.ValueConverters;

/// <summary>
/// Converts an RGB string to a Brush value.
/// </summary>
public class RgbStringBrushValueConverter : BaseValueConverter<RgbStringBrushValueConverter>
{
    /// <summary>
    /// Converts an RGB string to a Brush value.
    /// </summary>
    /// <param name="value">The RGB string value to convert.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">An optional parameter to use in the conversion.</param>
    /// <param name="culture">The culture to use in the conversion.</param>
    /// <returns>The converted Brush value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string rgbString)
        {
            try
            {
                var color = (Color)ColorConverter.ConvertFromString(rgbString);
                return new SolidColorBrush(color);
            }
            catch (FormatException)
            {
                // Handle incorrect format
            }
        }

        return new SolidColorBrush(Colors.Transparent);
    }

    /// <summary>
    /// Converts a Brush value to an RGB string.
    /// </summary>
    /// <param name="value">The Brush value to convert.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">An optional parameter to use in the conversion.</param>
    /// <param name="culture">The culture to use in the conversion.</param>
    /// <returns>The converted RGB string value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            var color = brush.Color;
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        return string.Empty;
    }
}