using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for ChatListItemControl.xaml
/// </summary>
public partial class ChatListItemControl : BaseControl<ChatListItemVM>
{
    public ChatListItemControl()
    {
        InitializeComponent();
    }

    protected override bool InheritsDataContext => true;
}