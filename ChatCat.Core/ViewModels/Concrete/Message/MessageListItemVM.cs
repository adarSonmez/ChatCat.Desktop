using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Message
{
    /// <summary>
    /// A view model for each meessage item in the message list
    /// </summary>
    public class MessageListItemVM : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Message text
        /// </summary>
        public string Text { get; set; } = default!;

        /// <summary>
        /// The date and time the message was sent
        /// </summary>
        public DateTimeOffset SentAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date and time the message was seen
        /// </summary>
        public DateTimeOffset SeenAt { get; set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// Indicates if the message is sent by the current user
        /// </summary>
        public bool IsOwnMessage { get; set; } = false;

        #endregion Public Properties
    }
}