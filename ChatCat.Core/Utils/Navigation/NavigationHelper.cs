using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;

namespace ChatCat.Core.Utils.Navigation
{
    /// <summary>
    /// Contains helper methods for navigating between pages.
    /// </summary>
    public static class NavigationHelper
    {
        /// <summary>
        /// Navigates to the specified page.
        /// </summary>
        /// <param name="page">The page to navigate to.</param>
        public static void NavigateTo(ApplicationPage page)
        {
            CoreLocator.ApplicationVM.CurrentPage = page;
        }
    }
}