using ChatCat.Core.ViewModels.Concrete.Message;
using ChatCat.Desktop.Controls.Base;

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