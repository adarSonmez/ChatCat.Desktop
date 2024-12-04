using ChatCat.Core.Constants.Enums;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;
using System.Windows.Input;

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

    /// <summary>
    /// Handles the preview mouse left button down event
    /// </summary>
    /// <param name="sender">The sender of the event</param>
    /// <param name="e">The event arguments</param>
    /// <remarks>Prevents "HidePopup" from being called when the user clicks on the popup</remarks>
    private void Popup_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        CoreLocator.AttachmentMenuVM.IsMenuVisible = true;
    }
}