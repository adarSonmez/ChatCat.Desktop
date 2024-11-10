using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete.Menu;
using ChatCat.Desktop.Controls.Base;
using System.ComponentModel;
using System.Windows;

namespace ChatCat.Desktop.Controls
{
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
}