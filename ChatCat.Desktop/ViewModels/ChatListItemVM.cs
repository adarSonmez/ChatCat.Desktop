using ChatCat.Desktop.ViewModels.Base;

namespace ChatCat.Desktop.ViewModels
{
    public class ChatListVM : BaseViewModel
    {
        public IList<ChatListItemVM> Items { get; set; }
    }
}