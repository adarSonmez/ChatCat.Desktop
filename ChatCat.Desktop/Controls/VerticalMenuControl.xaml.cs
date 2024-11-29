using ChatCat.Core.ViewModels.Concrete;
using ChatCat.Desktop.Controls.Base;

namespace ChatCat.Desktop.Controls;

/// <summary>
/// Interaction logic for MessageListControl.xaml
/// </summary>
public partial class VerticalMenuControl : BaseControl<MenuViewModel>
{
    public VerticalMenuControl()
    {
        InitializeComponent();
    }
}