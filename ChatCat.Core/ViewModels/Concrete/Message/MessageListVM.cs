using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for chat list on the side menu
/// </summary>
public class MessageListVM : BaseViewModel
{
    #region Constructors

    public MessageListVM()
    {
        if (ShowDesignTimeData)
        {
            Items =
            [
                new MessageListItemVM
                {
                    Text = "Hey, how are you?",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromDays(500),
                    IsOwnMessage = false,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromDays(90),
                },
                new MessageListItemVM
                {
                    Text = "I'm good, thanks! How are you?",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromDays(15),
                    IsOwnMessage = true,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromDays(15),
                },
                new MessageListItemVM
                {
                    Text = "I'm great, thanks for asking!",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromDays(1),
                    IsOwnMessage = false,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromDays(1)
                },
                new MessageListItemVM
                {
                    Text = "That's good to hear!",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromHours(3),
                    IsOwnMessage = true,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromHours(2),
                },
                new MessageListItemVM
                {
                    Text = "So, what are you up to today?",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromMinutes(3),
                    IsOwnMessage = false,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromMinutes(2)
                },
                new MessageListItemVM
                {
                    Text = "Not much, just relaxing at home.",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromSeconds(60),
                    IsOwnMessage = true,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromSeconds(60),
                },
                new MessageListItemVM
                {
                    Text = "Sounds nice, enjoy your day!",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromSeconds(60),
                    IsOwnMessage = false,
                    SeenAt = DateTimeOffset.Now - TimeSpan.FromSeconds(60)
                },
                new MessageListItemVM
                {
                    Text = "Thanks, you too!",
                    SentAt = DateTimeOffset.Now - TimeSpan.FromSeconds(20),
                    IsOwnMessage = true,
                },
                new MessageListItemVM
                {
                    Text = "Bye!",
                    SentAt = DateTimeOffset.Now,
                    IsOwnMessage = true,
                }
            ];
        }
    }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// The list of message list items.
    /// </summary>
    public IList<MessageListItemVM> Items { get; set; } = null!;

    #endregion Public Properties
}