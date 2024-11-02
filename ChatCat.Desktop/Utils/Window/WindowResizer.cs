using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace ChatCat.Desktop.Utils.Window
{
    /// <summary>
    /// The dock position of the window.
    /// </summary>
    public enum WindowDockPosition
    {
        Undocked,
        Left,
        Right,
    }

    internal enum MonitorOptions : uint
    {
        MONITOR_DEFAULTTONULL = 0x00000000,
        MONITOR_DEFAULTTOPRIMARY = 0x00000001,
        MONITOR_DEFAULTTONEAREST = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int Left, Top, Right, Bottom;
    }

    /// <summary>
    /// Fixes the issue with Windows of Style <see cref="WindowStyle.None"/> covering the taskbar.
    /// </summary>
    public class WindowResizer
    {
        private const int EdgeTolerance = 2;

        private readonly System.Windows.Window _window;
        private Rect _screenSize = new();
        private Matrix _transformToDevice;
        private nint _lastScreen;
        private WindowDockPosition _lastDock = WindowDockPosition.Undocked;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowResizer"/> class.
        /// </summary>
        /// <param name="window">The window to monitor and correctly maximize.</param>
        public WindowResizer(System.Windows.Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));

            GetTransform();

            _window.SourceInitialized += Window_SourceInitialized;
            _window.SizeChanged += Window_SizeChanged;
        }

        /// <summary>
        /// Occurs when the window dock position changes.
        /// </summary>
        public event EventHandler<WindowDockChangedEventArgs>? WindowDockChanged;

        private void GetTransform()
        {
            if (PresentationSource.FromVisual(_window) is PresentationSource source)
            {
                _transformToDevice = source.CompositionTarget.TransformToDevice;
            }
        }

        private void Window_SourceInitialized(object? sender, EventArgs e)
        {
            var handle = new WindowInteropHelper(_window).Handle;
            if (HwndSource.FromHwnd(handle) is HwndSource handleSource)
            {
                handleSource.AddHook(WindowProc);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_transformToDevice == default)
                return;

            var size = e.NewSize;

            var top = _window.Top;
            var left = _window.Left;
            var bottom = top + size.Height;
            var right = left + _window.Width;

            var windowTopLeft = _transformToDevice.Transform(new Point(left, top));
            var windowBottomRight = _transformToDevice.Transform(new Point(right, bottom));

            bool edgedTop = windowTopLeft.Y <= _screenSize.Top + EdgeTolerance;
            bool edgedLeft = windowTopLeft.X <= _screenSize.Left + EdgeTolerance;
            bool edgedBottom = windowBottomRight.Y >= _screenSize.Bottom - EdgeTolerance;
            bool edgedRight = windowBottomRight.X >= _screenSize.Right - EdgeTolerance;

            WindowDockPosition dock = WindowDockPosition.Undocked;

            if (edgedTop && edgedBottom && edgedLeft)
                dock = WindowDockPosition.Left;
            else if (edgedTop && edgedBottom && edgedRight)
                dock = WindowDockPosition.Right;

            if (dock != _lastDock)
                WindowDockChanged?.Invoke(this, new WindowDockChangedEventArgs(dock));

            _lastDock = dock;
        }

        private nint WindowProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
        {
            if (msg == NativeMethods.WM_GETMINMAXINFO)
            {
                WmGetMinMaxInfo(hwnd, lParam);
                handled = true;
            }

            return 0;
        }

        private void WmGetMinMaxInfo(nint hwnd, nint lParam)
        {
            if (!NativeMethods.GetCursorPos(out POINT mousePosition))
                return;

            var currentMonitor = NativeMethods.MonitorFromPoint(mousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            var monitorInfo = new MONITORINFO();
            monitorInfo.cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            if (!NativeMethods.GetMonitorInfo(currentMonitor, monitorInfo))
                return;

            if (currentMonitor != _lastScreen || _transformToDevice == default)
                GetTransform();

            _lastScreen = currentMonitor;

            var mmi = Marshal.PtrToStructure<MINMAXINFO>(lParam);

            mmi.ptMaxPosition.X = monitorInfo.rcWork.Left;
            mmi.ptMaxPosition.Y = monitorInfo.rcWork.Top;
            mmi.ptMaxSize.X = monitorInfo.rcWork.Right - monitorInfo.rcWork.Left;
            mmi.ptMaxSize.Y = monitorInfo.rcWork.Bottom - monitorInfo.rcWork.Top;

            var minSize = _transformToDevice.Transform(new Point(_window.MinWidth, _window.MinHeight));

            mmi.ptMinTrackSize.X = (int)minSize.X;
            mmi.ptMinTrackSize.Y = (int)minSize.Y;

            _screenSize = new Rect(mmi.ptMaxPosition.X, mmi.ptMaxPosition.Y, mmi.ptMaxSize.X, mmi.ptMaxSize.Y);

            Marshal.StructureToPtr(mmi, lParam, true);
        }
    }

    /// <summary>
    /// Provides data for the <see cref="WindowResizer.WindowDockChanged"/> event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="WindowDockChangedEventArgs"/> class.
    /// </remarks>
    /// <param name="dockPosition">The new dock position.</param>
    public class WindowDockChangedEventArgs(WindowDockPosition dockPosition) : EventArgs
    {
        /// <summary>
        /// Gets the dock position of the window.
        /// </summary>
        public WindowDockPosition DockPosition { get; } = dockPosition;
    }

    internal static class NativeMethods
    {
        public const int WM_GETMINMAXINFO = 0x0024;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo(nint hMonitor, [In, Out] MONITORINFO lpmi);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern nint MonitorFromPoint(POINT pt, MonitorOptions dwFlags);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal class MONITORINFO
    {
        public int cbSize;
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
    }
}