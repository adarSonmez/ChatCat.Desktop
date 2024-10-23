using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete.Auth;

namespace ChatCat.Desktop.Pages
{
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
    }
}