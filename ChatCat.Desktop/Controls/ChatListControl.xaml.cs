using ChatCat.Core.ViewModels.Concrete.Chat;
using System.Windows.Controls;

namespace ChatCat.Desktop.Controls
{
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
}