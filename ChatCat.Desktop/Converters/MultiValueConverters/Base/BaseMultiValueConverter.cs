using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ChatCat.Desktop.Converters.MultiValueConverters.Base;

/// <summary>
/// Base class for multi-value converters in the ChatCat.Desktop.Converters.Base namespace.
/// </summary>
/// <typeparam name="T">The derived class type.</typeparam>
public abstract class BaseMultiValueConverter<T> : MarkupExtension, IMultiValueConverter
    where T : class, new()
{
    #region Private Fields

    /// <summary>
    /// A single static instance of this value converter.
    /// </summary>
    private static T? _converter = null;

    #endregion Private Fields

    #region MarkupExtension Methods

    /// <inheritdoc/>
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter ??= new T();
    }

    #endregion MarkupExtension Methods

    #region IMultiValueConverter Methods

    /// <inheritdoc/>
    public abstract object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

    /// <inheritdoc/>
    public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

    #endregion IMultiValueConverter Methods
}