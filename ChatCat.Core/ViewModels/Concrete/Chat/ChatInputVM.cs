using ChatCat.Core.Commands;
using ChatCat.Core.Utils.Locator;
using ChatCat.Core.ViewModels.Abstract;
using System.Windows.Input;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for chat input control
/// </summary>
public class ChatInputVM : BaseViewModel
{
    #region Private Fields

    private readonly AttachmentMenuVM _attachmentMenuVM = CoreLocator.AttachmentMenuVM;

    #endregion Private Fields

    #region Commands

    /// <summary>
    /// The cammand to start the login process
    /// </summary>
    public ICommand ToggleAttachmentMenuCommand => new RelayCommand((_) => _attachmentMenuVM.IsMenuVisible = !_attachmentMenuVM.IsMenuVisible);

    #endregion Commands
}