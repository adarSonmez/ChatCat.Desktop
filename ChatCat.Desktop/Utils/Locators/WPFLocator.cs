using ChatCat.Core.Utils.IoC;
using ChatCat.Core.Utils.Locator;
using ChatCat.Desktop.ViewModels;

namespace ChatCat.Desktop.Utils.Locators
{
    /// <summary>
    /// Locates the view models for the WPF application
    /// </summary>
    public class WpfLocator : CoreLocator
    {
        #region View Model Locatings

        public static MainWindowVM MainWindowVM => DependencyResolver.Resolve<MainWindowVM>()!;

        #endregion View Model Locatings
    }
}