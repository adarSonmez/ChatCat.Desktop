using ChatCat.Core.Constants.Enums;
using ChatCat.Desktop.Converters.ValueConverters.Base;
using ChatCat.Desktop.Pages;
using System.Diagnostics;
using System.Globalization;

namespace ChatCat.Desktop.Converters.ValueConverters
{
    /// <summary>
    /// Converts an application page enum value to its corresponding page object.
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        /// <summary>
        /// Converts the specified value to its corresponding page object.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">An optional parameter for the conversion.</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>The corresponding page object.</returns>
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Register:
                    return new RegisterPage();

                case ApplicationPage.Chat:
                    return new ChatPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts the specified page object back to its corresponding enum value.
        /// </summary>
        /// <param name="value">The page object to be converted back.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">An optional parameter for the conversion.</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>The corresponding enum value.</returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}