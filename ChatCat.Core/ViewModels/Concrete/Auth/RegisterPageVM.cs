using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using System.Windows.Input;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// The View Model for a register screen
/// </summary>
public class RegisterPageVM : BaseViewModel
{
    #region Private Fields

    private bool _isRegisterRunning;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// The username of the user. Entered by the user in the register screen
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// A flag indicating if the register command is running
    /// </summary>
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

    /// <summary>
    /// The command to start the register process
    /// </summary>
    public ICommand RegisterCommand => new RelayCommand(async (parameter) => await Register(parameter));

    /// <summary>
    /// The command to navigate to the login page
    /// </summary>
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