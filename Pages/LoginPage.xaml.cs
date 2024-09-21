using ChatCat.Desktop.Animations;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
            PageLoadAnimation = PageAnimation.FadeIn;
            PageUnloadAnimation = PageAnimation.FadeOut;
        }
    }
}