using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Chat
{
    /// <summary>
    /// A view model for chat list on the side menu
    /// </summary>
    public class ChatListVM : BaseViewModel
    {
        #region Constructors

        public ChatListVM()
        {
            if (ShowDesignTimeData)
            {
                Items =
                [
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 3,
                        IsSelected = true
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "JG",
                        UserName = "John",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 1,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "JG",
                        UserName = "John",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 12,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    }
                ];
            }
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// The list of chat list items.
        /// </summary>
        public IList<ChatListItemVM> Items { get; set; } = null!;

        #endregion Public Properties
    }
}