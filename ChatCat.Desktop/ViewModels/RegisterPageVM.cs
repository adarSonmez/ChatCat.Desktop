using ChatCat.Desktop.Commands;
using ChatCat.Desktop.Constants.Enums;
using ChatCat.Desktop.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatCat.Desktop.ViewModels
{
    public class RegisterPageVM : BaseViewModel
    {
        #region Private Fields

        private bool _registerIsRunning;

        #endregion Private Fields

        #region Public Properties

        public string? Username { get; set; }

        public bool RegisterIsRunning
        {
            get => _registerIsRunning;
            set
            {
                if (_registerIsRunning != value)
                {
                    _registerIsRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Commands

        public ICommand RegisterCommand => new RelayCommand(async (parameter) => await Register(parameter));

        public ICommand NavigateToLoginCommand => new RelayCommand(async (mull) => await NavigateToLoginPageAsync());

        #endregion Commands

        #region Constructors

        public RegisterPageVM()
        {
        }

        #endregion Constructors

        #region Private Methods

        private async Task Register(object? parameter)
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(1000);

                var username = Username;
                var password = (parameter as PasswordBox)?.SecurePassword;

                return await Task.FromResult(true);
            });
        }

        private async Task NavigateToLoginPageAsync()
        {
            ((MainWindowVM)Application.Current.MainWindow.DataContext).CurrentPage = ApplicationPage.Login;
            await Task.CompletedTask;
        }

        #endregion Private Methods
    }
}