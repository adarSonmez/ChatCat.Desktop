using ChatCat.Desktop.Animations;
using ChatCat.Desktop.ViewModels;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterPageVM>
    {
        public RegisterPage()
        {
            PageLoadAnimation = PageAnimation.FadeIn;
            PageUnloadAnimation = PageAnimation.FadeOut;

            InitializeComponent();
        }
    }
}