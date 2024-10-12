using ChatCat.Core.Commands;
using ChatCat.Core.ViewModels.Abstract;
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

        private Window _mainWindow;
        private int _outerMarginSize = 10;
        private int _windowRadiusSize = 12;

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

        #endregion Public Properties

        #region Commands

        public ICommand MinimizeCommand => new RelayCommand((_) => _mainWindow.WindowState = WindowState.Minimized);
        public ICommand MaximizeCommand => new RelayCommand((_) => _mainWindow.WindowState ^= WindowState.Maximized);
        public ICommand CloseCommand => new RelayCommand((_) => _mainWindow.Close());
        public ICommand MenuCommand => new RelayCommand((_) => SystemCommands.ShowSystemMenu(_mainWindow, GetMousePosition()));

        #endregion Commands

        #region Constructors

        public MainWindowVM(Window mainWindow)
        {
            _mainWindow = mainWindow;

            _mainWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadiusSize));
                OnPropertyChanged(nameof(BorderRadiusThickness));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }

        #endregion Constructors

        #region Private Methods

        /// <summary>
        /// Gets the current mouse position relative to the screen.
        /// </summary>
        /// <returns>The mouse position.</returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_mainWindow);
            return new Point(position.X + _mainWindow.Left, position.Y + _mainWindow.Top);
        }

        #endregion Private Methods
    }
}