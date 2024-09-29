using ChatCat.Desktop.Animations;
using ChatCat.Desktop.ViewModels;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<LoginPageVM>
    {
        public ChatPage()
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromLeft;
            PageUnloadAnimation = PageAnimation.SlideAndFadeOutToLeft;

            InitializeComponent();
        }
    }
}