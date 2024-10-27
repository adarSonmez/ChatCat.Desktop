using ChatCat.Core.ViewModels.Concrete.Chat;
using ChatCat.Core.ViewModels.Concrete.Message;

namespace ChatCat.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for MessageListControl.xaml
    /// </summary>
    public partial class MessageListControl : BaseControl<MessageListVM>
    {
        public MessageListControl()
        {
            InitializeComponent();
        }
    }
}