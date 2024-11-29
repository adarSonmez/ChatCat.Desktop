using ChatCat.Desktop.Converters.ValueConverters.Base;
using System.Globalization;

namespace ChatCat.Desktop.Converters.ValueConverters;

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

    /// <exception cref="NotImplementedException">This method is not implemented.</exception>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}