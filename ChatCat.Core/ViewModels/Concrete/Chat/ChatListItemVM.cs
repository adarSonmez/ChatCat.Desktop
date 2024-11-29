using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for each chat list item in the chat list
/// </summary>
public class ChatListItemVM : BaseViewModel
{
    #region Public Properties

    /// <summary>
    /// The display name of the user
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// The latest message from this chat
    /// </summary>
    public string LastMessage { get; set; } = default!;

    /// <summary>
    /// The initials of the user. Generally between 1 and 3 characters
    /// </summary>
    public string Initials { get; set; } = default!;

    /// <summary>
    /// Indicates if this chat list item is selected.
    /// </summary>
    /// <remarks>Selected chat list items are highlighted</remarks>
    public bool IsSelected { get; set; }

    /// <summary>
    /// The number of new messages in this chat
    /// </summary>
    /// <remarks>If not zero, a badge will be displayed</remarks>
    public int NewMessageCount { get; set; }

    #endregion Public Properties
}