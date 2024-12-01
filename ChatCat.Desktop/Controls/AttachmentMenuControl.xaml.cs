using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for AttachmentMenuControl.xaml
/// </summary>
public partial class AttachmentMenuControl : BaseControl<AttachmentMenuVM>
{
    public AttachmentMenuControl()
    {
        ControlLoadAnimation = FrameworkAnimationType.SlideAndFadeInFromBottom;
        ControlUnloadAnimation = FrameworkAnimationType.SlideAndFadeOutToBottom;

        InitializeComponent();
    }
}