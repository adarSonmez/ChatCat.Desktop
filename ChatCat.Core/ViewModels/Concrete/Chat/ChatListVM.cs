using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Chat
{
    /// <summary>
    /// A view model for chat list on the side menu
    /// </summary>
    public class ChatListVM : BaseViewModel
    {
        public required IList<ChatListItemVM> Items { get; set; }
    }
}