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

        public ApplicationPage CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}