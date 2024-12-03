using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for the attachment menu
/// </summary>
public class AttachmentMenuVM : BaseViewModel
{
    #region Private Fields

    private bool _isMenuVisible;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// Indicates if attachment menu is visible
    /// </summary>
    public bool IsMenuVisible
    {
        get => _isMenuVisible;
        set
        {
            if (_isMenuVisible != value)
            {
                _isMenuVisible = value;
                OnPropertyChanged();
            }
        }
    }

    #endregion Public Properties

    #region Constructors

    public AttachmentMenuVM()
    {
        if (ShowDesignTimeData)
        {
            Items =
             [
                new MenuItemVM { Text = "Attach a File", ItemType = MenuItemType.Header },
                new MenuItemVM { Text = "From Computer", ItemType = MenuItemType.TextAndIcon, Icon = "\uf0c7" },
                new MenuItemVM { Text = "From OneDrive", ItemType = MenuItemType.TextAndIcon, Icon = "\uf0c2" },
            ];
        }
    }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// The items in this menu
    /// </summary>
    public IEnumerable<MenuItemVM> Items { get; set; } = null!;

    #endregion Public Properties
}