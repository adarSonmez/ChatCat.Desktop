using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete;

namespace ChatCat.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : BaseControl<SharedVM>
    {
        public SideMenuControl()
        {
            InitializeComponent();
            ControlLoadAnimation = FrameworkAnimationType.SlideAndFadeInFromLeft;
            ControlUnloadAnimation = FrameworkAnimationType.SlideAndFadeOutToLeft;
        }
    }
}