using ChatCat.Core.ViewModels.Base;

namespace ChatCat.Core.ViewModels
{
    public class ChatListVM : BaseViewModel
    {
        public IList<ChatListItemVM> Items { get; set; }
    }
}