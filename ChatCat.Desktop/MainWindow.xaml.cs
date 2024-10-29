using ChatCat.Desktop.ViewModels;
using System.Windows;

namespace ChatCat.Desktop
{
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
    }
}