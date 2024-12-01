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
                new MenuItemVM { Text = "Header 1", ItemType = MenuItemType.Header },
                new MenuItemVM { Text = "Item 1", ItemType = MenuItemType.TextAndIcon, Icon = "\uf015" },
                new MenuItemVM { Text = "Item 2", ItemType = MenuItemType.TextAndIcon, Icon = "\uf002" },
                new MenuItemVM { Text = "Item 3", ItemType = MenuItemType.TextAndIcon, Icon = "\uf007" },
                new MenuItemVM { ItemType = MenuItemType.Divider },
                new MenuItemVM { Text = "Header 2", ItemType = MenuItemType.Header },
                new MenuItemVM { Text = "Item 4", ItemType = MenuItemType.TextAndIcon, Icon = "\uf008" },
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