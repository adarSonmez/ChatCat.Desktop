using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for MessageListItemControl.xaml
/// </summary>
public partial class MessageListItemControl : BaseControl<MessageListItemVM>
{
    public MessageListItemControl()
    {
        InitializeComponent();
    }

    protected override bool InheritsDataContext => true;
}