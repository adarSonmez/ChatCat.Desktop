using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for a menu
/// </summary>
public class MenuViewModel : BaseViewModel
{
    #region Constructors

    public MenuViewModel()
    {
        if (ShowDesignTimeData)
        {
            Items =
             [
                new MenuItemViewModel { Text = "Header 1", ItemType = MenuItemType.Header },
                new MenuItemViewModel { Text = "Item 1", ItemType = MenuItemType.TextAndIcon, Icon = "f015" },
                new MenuItemViewModel { Text = "Item 2", ItemType = MenuItemType.TextAndIcon, Icon = "f002" },
                new MenuItemViewModel { Text = "Item 3", ItemType = MenuItemType.TextAndIcon, Icon = "f007" },
                new MenuItemViewModel { ItemType = MenuItemType.Divider },
                new MenuItemViewModel { Text = "Header 2", ItemType = MenuItemType.TextAndIcon, Icon = "f099" },
                new MenuItemViewModel { Text = "Item 4", ItemType = MenuItemType.TextAndIcon, Icon = "f16d" },
            ];
        }
    }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// The items in this menu
    /// </summary>
    public IEnumerable<MenuItemViewModel> Items { get; set; } = null!;

    #endregion Public Properties
}