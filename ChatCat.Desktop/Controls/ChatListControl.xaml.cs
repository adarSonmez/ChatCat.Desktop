using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for ChatListControl.xaml
/// </summary>
public partial class ChatListControl : BaseControl<ChatListVM>
{
    public ChatListControl()
    {
        InitializeComponent();
    }
}