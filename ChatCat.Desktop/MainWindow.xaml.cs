using ChatCat.Core.ViewModels.Concrete.Application;
using ChatCat.Desktop.ViewModels;
using System.Windows;

namespace ChatCat.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM(this);
        }
    }
}