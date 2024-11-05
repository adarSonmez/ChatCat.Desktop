using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;
using System.Windows.Data;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts a DateTimeOffset value to a status message based on the parameter.
    /// </summary>
    public class DateTimeOffsetToTimedMessageStatusValueConverter : BaseValueConverter<DateTimeOffsetToTimedMessageStatusValueConverter>
    {
        /// <summary>
        /// Converts the specified DateTimeOffset to a status message.
        /// </summary>
        /// <param name="value">The DateTimeOffset value to be converted.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The status type (e.g., "Sent" or "Seen").</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>A formatted status message, or null if the value is invalid.</returns>
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTimeOffset dateTimeOffset && parameter is string statusType)
            {
                if (dateTimeOffset == DateTimeOffset.MinValue)
                {
                    return $"Not {statusType.ToLower()} yet.";
                }

                string formattedTime = dateTimeOffset.ToString("dd/MM/yyyy HH:mm", culture);
                return $"{statusType} {formattedTime}";
            }

            return null;
        }

        /// <exception cref="NotImplementedException">This method is not implemented.</exception>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}