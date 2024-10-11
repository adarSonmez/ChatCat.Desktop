﻿using ChatCat.Desktop.Commands;
using ChatCat.Desktop.Constants.Enums;
using ChatCat.Desktop.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatCat.Desktop.ViewModels
{
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

        public ICommand NavigateToRegisterCommand => new RelayCommand(async (mull) => await NavigateToRegisterPageAsync());

        #endregion Commands

        #region Constructors

        public LoginPageVM()
        {
        }

        #endregion Constructors

        #region Private Methods

        private async Task LoginAsync(object? parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                var username = Username;
                var password = (parameter as PasswordBox)?.SecurePassword;

                return await Task.FromResult(true);
            });
        }

        private async Task NavigateToRegisterPageAsync()
        {
            ((MainWindowVM)Application.Current.MainWindow.DataContext).CurrentPage = ApplicationPage.Register;

            await Task.CompletedTask;
        }

        #endregion Private Methods
    }
}