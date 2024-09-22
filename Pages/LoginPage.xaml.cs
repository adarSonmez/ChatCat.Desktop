using ChatCat.Desktop.Animations;
using ChatCat.Desktop.ViewModels;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageVM>
    {
        public LoginPage()
        {
            InitializeComponent();
            PageLoadAnimation = PageAnimation.FadeIn;
            PageUnloadAnimation = PageAnimation.FadeOut;
        }
    }
}