using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using System.Windows.Input;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// The View Model for a login screen
/// </summary>
public class LoginPageVM : BaseViewModel
{
    #region Private Fields

    private bool _isLoginRunning;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// The username of the user. Entered by the user in the login screen
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// A flag indicating if the login command is running
    /// </summary>
    public bool IsLoginRunning
    {
        get => _isLoginRunning;
        set
        {
            if (_isLoginRunning != value)
            {
                _isLoginRunning = value;
                OnPropertyChanged();
            }
        }
    }

    #endregion Public Properties

    #region Commands

    /// <summary>
    /// The cammand to start the login process
    /// </summary>
    public ICommand LoginCommand => new RelayCommand(async (parameter) => await LoginAsync(parameter));

    /// <summary>
    /// The command to navigate to the register page
    /// </summary>
    public ICommand NavigateToRegisterCommand => new RelayCommand((_) => CoreLocator.ApplicationVM.NavigateTo(ApplicationPage.Register));

    #endregion Commands

    #region Private Methods

    private async Task LoginAsync(object? parameter)
    {
        await RunCommandAsync(() => IsLoginRunning, async () =>
        {
            await Task.Delay(1000);

            var username = Username;
            var password = (parameter as dynamic)?.SecurePassword;

            CoreLocator.ApplicationVM.NavigateTo(ApplicationPage.Chat);

            return await Task.FromResult(true);
        });
    }

    #endregion Private Methods
}