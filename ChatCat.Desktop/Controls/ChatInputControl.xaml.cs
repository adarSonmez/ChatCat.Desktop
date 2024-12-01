using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for ChatInputControl.xaml
/// </summary>
public partial class ChatInputControl : BaseControl<ChatInputVM>
{
    public ChatInputControl()
    {
        InitializeComponent();
    }
}