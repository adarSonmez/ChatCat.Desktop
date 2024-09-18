using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;
using System.Windows;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts a boolean value to a visibility value.
    /// </summary>
    internal class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        /// <summary>
        /// Converts a boolean value to a visibility value.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional parameter to use in the conversion.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>The converted visibility value.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a visibility value to a boolean value.
        /// </summary>
        /// <param name="value">The visibility value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional parameter to use in the conversion.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>The converted boolean value.</returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}