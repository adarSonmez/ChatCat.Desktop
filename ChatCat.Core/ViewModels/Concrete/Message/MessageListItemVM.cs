using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete.Message
{
    /// <summary>
    /// A view model for each meessage item in the message list
    /// </summary>
    public class MessageListItemVM : BaseViewModel
    {
        #region Public Properties

        public string Text { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsOwnMessage { get; set; } = false;

        #endregion Public Properties
    }
}