using ChatCat.Core.Constants.Enums;

namespace ChatCat.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : BaseControl
    {
        public SideMenuControl()
        {
            InitializeComponent();
            ControlLoadAnimation = FrameworkAnimationType.SlideAndFadeInFromLeft;
            ControlUnloadAnimation = FrameworkAnimationType.SlideAndFadeOutToLeft;
        }
    }
}