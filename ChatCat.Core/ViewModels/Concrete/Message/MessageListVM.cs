using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Core.ViewModels.Concrete.Chat;

namespace ChatCat.Core.ViewModels.Concrete.Message
{
    /// <summary>
    /// A view model for chat list on the side menu
    /// </summary>
    public class MessageListVM : BaseViewModel
    {
        public IList<MessageListItemVM> Items { get; set; } =
        [
            new MessageListItemVM { Text = "Hello", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "Hi", CreatedAt = DateTime.Now, IsOwnMessage = false },
            new MessageListItemVM { Text = "How are you?", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "I'm fine", CreatedAt = DateTime.Now, IsOwnMessage = false },
            new MessageListItemVM { Text = "Good to hear", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "How about you?", CreatedAt = DateTime.Now, IsOwnMessage = false },
            new MessageListItemVM { Text = "I'm good", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "That's great", CreatedAt = DateTime.Now, IsOwnMessage = false },
            new MessageListItemVM { Text = "What are you doing?", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "Nothing much", CreatedAt = DateTime.Now, IsOwnMessage = false },
            new MessageListItemVM { Text = "Just chilling", CreatedAt = DateTime.Now, IsOwnMessage = true },
            new MessageListItemVM { Text = "Cool", CreatedAt = DateTime.Now, IsOwnMessage = false },
        ];
    }
}