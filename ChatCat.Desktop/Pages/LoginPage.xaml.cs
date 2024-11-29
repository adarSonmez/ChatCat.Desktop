using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete;
using System.Windows.Input;

namespace ChatCat.Desktop.Pages;

/// <summary>
/// Interaction logic for LoginPage.xaml
/// </summary>
public partial class LoginPage : BasePage<LoginPageVM>
{
    public LoginPage()
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