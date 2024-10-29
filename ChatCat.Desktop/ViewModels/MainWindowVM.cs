using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Core.ViewModels.Concrete.Application;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ChatCat.Desktop.ViewModels
{
    /// <summary>
    /// The View Model for the main window of the application.
    /// </summary>
    public class MainWindowVM : BaseViewModel
    {
        #region Private Fields

        private readonly ApplicationVM _applicationVM;
        private Window _mainWindow = null!;
        private int _outerMarginSize = 10;
        private int _windowRadiusSize = 12;
        private Visibility _minimizaMaximizeBtnVisibility = Visibility.Visible;

        #endregion Private Fields

        #region Public Properties

        public Window MainWindow
        {
            get => _mainWindow;
            set
            {
                if (_mainWindow != value)
                {
                    _mainWindow = value;
                    OnPropertyChanged();
                }

                _mainWindow.StateChanged += (sender, e) =>
                {
                    OnPropertyChanged(nameof(OuterMarginSize));
                    OnPropertyChanged(nameof(OuterMarginSizeThickness));
                    OnPropertyChanged(nameof(WindowRadiusSize));
                    OnPropertyChanged(nameof(BorderRadiusThickness));
                    OnPropertyChanged(nameof(WindowCornerRadius));
                };

                UpdateWindowResizability();
            }
        }

        public Thickness BorderRadiusThickness => new(ResizeBorderSize + OuterMarginSize);
        public Thickness OuterMarginSizeThickness => new(OuterMarginSize);
        public CornerRadius WindowCornerRadius => new(WindowRadiusSize);
        public GridLength TitleHeightGridLength => new(TitleBarHeight + ResizeBorderSize);
        public int TitleBarHeight { get; set; } = 32;
        public int ResizeBorderSize { get; set; } = 12;

        public int WindowRadiusSize
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _windowRadiusSize;
            set => _windowRadiusSize = value;
        }

        public int OuterMarginSize
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        public Visibility MinimizaMaximizeBtnVisibility
        {
            get => _minimizaMaximizeBtnVisibility;
            set
            {
                if (_minimizaMaximizeBtnVisibility != value)
                {
                    _minimizaMaximizeBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Commands

        public ICommand MinimizeCommand => new RelayCommand((_) => _mainWindow.WindowState = WindowState.Minimized);
        public ICommand MaximizeCommand => new RelayCommand((_) => _mainWindow.WindowState ^= WindowState.Maximized);
        public ICommand CloseCommand => new RelayCommand((_) => _mainWindow.Close());
        public ICommand MenuCommand => new RelayCommand((_) => SystemCommands.ShowSystemMenu(_mainWindow, GetMousePosition()));

        #endregion Commands

        #region Constructors

        public MainWindowVM()
        {
            _applicationVM = CoreLocator.ApplicationVM;
            _applicationVM.PropertyChanged += ApplicationVM_PropertyChanged;
        }

        #endregion Constructors

        #region Event Handlers

        private void ApplicationVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ApplicationVM.CurrentPage))
            {
                UpdateWindowResizability();
            }
        }

        #endregion Event Handlers

        #region Private Methods

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_mainWindow);
            return new Point(position.X + _mainWindow.Left, position.Y + _mainWindow.Top);
        }

        private void UpdateWindowResizability()
        {
            switch (_applicationVM.CurrentPage)
            {
                case ApplicationPage.Login:
                case ApplicationPage.Register:
                    _mainWindow.ResizeMode = ResizeMode.NoResize;
                    MinimizaMaximizeBtnVisibility = Visibility.Collapsed;
                    break;

                default:
                    _mainWindow.ResizeMode = ResizeMode.CanResize;
                    MinimizaMaximizeBtnVisibility = Visibility.Visible;
                    break;
            }
        }

        #endregion Private Methods
    }
}