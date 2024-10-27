using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;
using System.Windows;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts a value to a visibility value based on if it is greater than a parameter.
    /// </summary>
    public class GreaterThanToVisibilityValueConverter : BaseValueConverter<GreaterThanToVisibilityValueConverter>
    {
        /// <summary>
        /// Converts a value to a visibility value based on if it is greater than a parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The parameter to compare against.</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>A visibility value based on if the value is greater than the parameter.</returns>
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value?.ToString(), out double doubleValue) && double.TryParse(parameter?.ToString(), out double doubleParameter))
            {
                return doubleValue > doubleParameter ? Visibility.Visible : Visibility.Collapsed;
            }

            return false;
        }

        /// <summary>
        /// Converts a visibility value back to a value.
        /// </summary>
        /// <param name="value">The value to convert back.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The parameter to compare against.</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>The original value.</returns>
        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}