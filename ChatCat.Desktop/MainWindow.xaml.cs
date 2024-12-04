using ChatCat.Core.Utils.Locator;
using ChatCat.Desktop.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ChatCat.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowVM viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
        viewModel.MainWindow = this;
    }

    /// <summary>
    /// Handles the preview mouse left button down event. Hides all popups when the user clicks on the main border.
    /// </summary>
    /// <param name="sender">The sender of the event</param>
    /// <param name="e">The event arguments</param>
    /// <remarks>Add other popups to the if statement if needed.</remarks>
    private void MainBorder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CoreLocator.AttachmentMenuVM.IsMenuVisible = false;
    }
}