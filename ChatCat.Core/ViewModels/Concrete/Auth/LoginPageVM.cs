using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using System.Windows.Input;

namespace ChatCat.Core.ViewModels.Concrete.Auth
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginPageVM : BaseViewModel
    {
        #region Private Fields

        private bool _loginIsRunning;

        #endregion Private Fields

        #region Public Properties

        public string? Username { get; set; }

        public bool LoginIsRunning
        {
            get => _loginIsRunning;
            set
            {
                if (_loginIsRunning != value)
                {
                    _loginIsRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Commands

        public ICommand LoginCommand => new RelayCommand(async (parameter) => await LoginAsync(parameter));

        public ICommand NavigateToRegisterCommand => new RelayCommand((_) => NavigateToRegisterPage());

        #endregion Commands

        #region Private Methods

        private async Task LoginAsync(object? parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                var username = Username;
                var password = (parameter as dynamic)?.SecurePassword;

                return await Task.FromResult(true);
            });
        }

        private void NavigateToRegisterPage()
        {
            CoreLocator.ApplicationVM.CurrentPage = ApplicationPage.Register;
        }

        #endregion Private Methods
    }
}