using ChatCat.Core.Commands;
using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Core.ViewModels.Concrete.Application;
using ChatCat.Desktop.Utils.Window;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ChatCat.Desktop.ViewModels
{
    /// <summary>
    /// The ViewModel for the main window of the application, handling window state and appearance.
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

        /// <summary>
        /// Gets or sets the main window of the application.
        /// </summary>
        /// <remarks>This property should be set in the <see cref="Desktop.MainWindow"/> constructor.</remarks>
        public Window MainWindow
        {
            get => _mainWindow;
            set
            {
                if (_mainWindow != value)
                {
                    _mainWindow = value;

                    // Fix for the issue with Windows of Style WindowStyle.None covering the taskbar
                    _ = new WindowResizer(_mainWindow);
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

                UpdatePageSpecificWindowProperties();
            }
        }

        /// <summary>
        /// Gets the total thickness of the border radius, calculated from the resize border and outer margin sizes.
        /// </summary>
        public Thickness BorderRadiusThickness => new(ResizeBorderSize + OuterMarginSize);

        /// <summary>
        /// Gets the thickness of the outer margin around the window.
        /// </summary>
        public Thickness OuterMarginSizeThickness => new(OuterMarginSize);

        /// <summary>
        /// Gets the corner radius of the window, which determines the roundness of the window corners.
        /// </summary>
        public CornerRadius WindowCornerRadius => new(WindowRadiusSize);

        /// <summary>
        /// Gets the total height of the title bar, including the resize border.
        /// </summary>
        public GridLength TitleHeightGridLength => new(TitleBarHeight + ResizeBorderSize);

        /// <summary>
        /// Gets or sets the height of the title bar.
        /// </summary>
        public int TitleBarHeight { get; set; } = 32;

        /// <summary>
        /// Gets or sets the size of the resize border around the window.
        /// </summary>
        public int ResizeBorderSize { get; set; } = 12;

        /// <summary>
        /// Gets the size of the window's corner radius, which is zero when maximized.
        /// </summary>
        public int WindowRadiusSize
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _windowRadiusSize;
            set => _windowRadiusSize = value;
        }

        /// <summary>
        /// Gets the size of the outer margin, which is zero when the window is maximized.
        /// </summary>
        public int OuterMarginSize
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// Gets or sets the visibility of the minimize and maximize buttons based on the current application page.
        /// </summary>
        public Visibility MinimizeMaximizeBtnVisibility
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

        /// <summary>
        /// Gets the command to minimize the main window.
        /// </summary>
        public ICommand MinimizeCommand => new RelayCommand(_ => _mainWindow.WindowState = WindowState.Minimized);

        /// <summary>
        /// Gets the command to maximize or restore the main window.
        /// </summary>
        public ICommand MaximizeCommand => new RelayCommand(_ => _mainWindow.WindowState ^= WindowState.Maximized);

        /// <summary>
        /// Gets the command to close the main window.
        /// </summary>
        public ICommand CloseCommand => new RelayCommand(_ => _mainWindow.Close());

        /// <summary>
        /// Gets the command to display the system menu at the current mouse position.
        /// </summary>
        public ICommand MenuCommand => new RelayCommand(_ => SystemCommands.ShowSystemMenu(_mainWindow, GetMousePosition()));

        #endregion Commands

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVM"/> class.
        /// </summary>
        public MainWindowVM()
        {
            _applicationVM = CoreLocator.ApplicationVM;
            _applicationVM.PropertyChanged += ApplicationVM_PropertyChanged;
        }

        #endregion Constructors

        #region Event Handlers

        /// <summary>
        /// Handles property changes in the <see cref="ApplicationVM"/>, updating the window's resizability when the current page changes.
        /// </summary>
        private void ApplicationVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ApplicationVM.CurrentPage))
            {
                UpdatePageSpecificWindowProperties();
            }
        }

        #endregion Event Handlers

        #region Private Methods

        /// <summary>
        /// Gets the current mouse position relative to the screen.
        /// </summary>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_mainWindow);
            return new Point(position.X + _mainWindow.Left, position.Y + _mainWindow.Top);
        }

        /// <summary>
        /// Updates the window's resizability and button visibility based on the current application page.
        /// </summary>
        private void UpdatePageSpecificWindowProperties()
        {
            switch (_applicationVM.CurrentPage)
            {
                case ApplicationPage.Login:
                case ApplicationPage.Register:
                    _mainWindow.ResizeMode = ResizeMode.NoResize;
                    MinimizeMaximizeBtnVisibility = Visibility.Collapsed;
                    break;

                default:
                    if (_mainWindow.ResizeMode == ResizeMode.NoResize)
                    {
                        _mainWindow.Width = 1000;
                        _mainWindow.Height = 700;
                        _mainWindow.Left = (SystemParameters.PrimaryScreenWidth - _mainWindow.Width) / 2;
                        _mainWindow.Top = (SystemParameters.PrimaryScreenHeight - _mainWindow.Height) / 2;
                    }

                    _mainWindow.ResizeMode = ResizeMode.CanResize;
                    MinimizeMaximizeBtnVisibility = Visibility.Visible;
                    break;
            }
        }

        #endregion Private Methods
    }
}