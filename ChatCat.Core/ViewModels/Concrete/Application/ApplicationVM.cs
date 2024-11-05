using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Application
{
    /// <summary>
    /// Represents the application view model.
    /// </summary>
    public class ApplicationVM : BaseViewModel
    {
        private ApplicationPage _currentPage = ApplicationPage.Login;

        /// <summary>
        /// The current page of the application.
        /// </summary>
        /// <remarks>To change the current page, use the <see cref="NavigateTo"/> method.</remarks>
        public ApplicationPage CurrentPage
        {
            get => _currentPage;
            private set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Public Methods

        /// <summary>
        /// Navigates to the specified page.
        /// </summary>
        /// <param name="page">The page to navigate to.</param>
        public void NavigateTo(ApplicationPage page)
        {
            CurrentPage = page;
        }

        #endregion Public Methods
    }
}