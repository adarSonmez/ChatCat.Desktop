using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts a <see cref="DateTimeOffset"/> to a human-readable "time ago" string.
    /// </summary>
    public class DateTimeOffsetToTimeAgoValueConverter : BaseValueConverter<DateTimeOffsetToTimeAgoValueConverter>
    {
        /// <summary>
        /// Converts a <see cref="DateTimeOffset"/> to a "time ago" string.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> value to convert.</param>
        /// <param name="targetType">The target type of the conversion (not used).</param>
        /// <param name="parameter">Optional parameter for the conversion (not used).</param>
        /// <param name="culture">The culture to use in the converter (not used).</param>
        /// <returns>A human-readable "time ago" string.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTimeOffset)value;

            if (dateTime == DateTimeOffset.MinValue)
                return string.Empty;

            var timeAgo = DateTime.Now - dateTime;

            // Determine the appropriate time ago string using a switch expression
            return timeAgo.TotalSeconds switch
            {
                < 60 => "Just now",
                < 3600 => $"{timeAgo.Minutes} minutes ago",
                < 86400 => $"{timeAgo.Hours} hours ago",
                < 2592000 => $"{timeAgo.Days} days ago",
                < 31536000 => $"{timeAgo.Days / 30} months ago",
                _ => $"{timeAgo.Days / 365} years ago"
            };
        }

        /// <summary>
        /// Converts a value back to a <see cref="DateTimeOffset"/> (not implemented).
        /// </summary>
        /// <param name="value">The value produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">Optional parameter for the conversion.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A <see cref="DateTimeOffset"/> value.</returns>
        /// <exception cref="NotImplementedException">Thrown always as this method is not implemented.</exception>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}