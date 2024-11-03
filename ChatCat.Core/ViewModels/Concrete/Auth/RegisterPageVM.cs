using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using System.Windows.Input;

#pragma warning disable CA1822

namespace ChatCat.Core.ViewModels.Concrete.Auth
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class RegisterPageVM : BaseViewModel
    {
        #region Private Fields

        private bool _isRegisterRunning;

        #endregion Private Fields

        #region Public Properties

        public string? Username { get; set; }

        public bool IsRegisterRunning
        {
            get => _isRegisterRunning;
            set
            {
                if (_isRegisterRunning != value)
                {
                    _isRegisterRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Commands

        public ICommand RegisterCommand => new RelayCommand(async (parameter) => await Register(parameter));

        public ICommand NavigateToLoginCommand => new RelayCommand((_) => CoreLocator.ApplicationVM.NavigateTo(ApplicationPage.Login));

        #endregion Commands

        #region Private Methods

        private async Task Register(object? parameter)
        {
            await RunCommandAsync(() => IsRegisterRunning, async () =>
            {
                await Task.Delay(1000);

                var username = Username;
                var password = (parameter as dynamic)?.SecurePassword;

                return await Task.FromResult(true);
            });
        }

        #endregion Private Methods
    }
}