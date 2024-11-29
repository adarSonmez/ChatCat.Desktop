using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete;
using System.Windows.Input;

namespace ChatCat.Desktop.Pages;

/// <summary>
/// Interaction logic for RegisterPage.xaml
/// </summary>
public partial class RegisterPage : BasePage<RegisterPageVM>
{
    public RegisterPage()
    {
        PageLoadAnimation = FrameworkAnimationType.FadeIn;
        PageUnloadAnimation = FrameworkAnimationType.FadeOut;

        InitializeComponent();
    }

    private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        UsernameTextBox.Focus();
        Keyboard.Focus(UsernameTextBox);
    }
}