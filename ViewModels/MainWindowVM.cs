using ChatCat.Desktop.ViewModels.Base;
using System.Windows;

namespace ChatCat.Desktop.ViewModels
{
    internal class MainWindowVM : BaseViewModel
    {
        #region Private Fields

        private Window _mainWindow;
        private int _outerMarginSize = 10;
        private int _windowRadiusSize = 16;

        #endregion Private Fields

        #region Public Properties

        public Window MainWindow
        {
            get => _mainWindow;
            set
            {
                _mainWindow = value;
                OnPropertyChanged(nameof(MainWindow));
            }
        }

        public Thickness BorderRadiusThickness => new(ResizeBorderSize + OuterMarginSize);
        public Thickness OuterMarginSizeThickness => new(OuterMarginSize);
        public CornerRadius WindowCornerRadius => new(WindowRadiusSize);

        public int TitleBarHeight { get; set; } = 42;
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
    }
}