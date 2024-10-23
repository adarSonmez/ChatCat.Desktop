using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Chat
{
    /// <summary>
    /// A view model for each chat list item in the chat list
    /// </summary>
    public class ChatListItemVM : BaseViewModel
    {
        #region Public Properties

        public string UserName { get; set; } = default!;

        public string LastMessage { get; set; } = default!;

        public string Initials { get; set; } = default!;

        public bool IsSelected { get; set; } = false;

        public int NewMessageCount { get; set; } = 0;

        #endregion Public Properties
    }
}