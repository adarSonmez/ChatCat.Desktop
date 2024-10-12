using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete.Auth;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageVM>
    {
        public LoginPage()
        {
            PageLoadAnimation = PageAnimation.FadeIn;
            PageUnloadAnimation = PageAnimation.FadeOut;

            InitializeComponent();
        }
    }
}