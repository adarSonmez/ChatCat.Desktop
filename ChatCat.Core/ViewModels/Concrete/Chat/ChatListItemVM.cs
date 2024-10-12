using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Chat
{
    /// <summary>
    /// A view model for each chat list item in the chat list
    /// </summary>
    public class ChatListItemVM : BaseViewModel
    {
        #region Public Properties

        public required string UserName { get; set; }

        public required string LastMessage { get; set; }

        public required string Initials { get; set; }

        public bool IsSelected { get; set; } = false;

        public int NewMessageCount { get; set; } = 0;

        #endregion Public Properties
    }
}