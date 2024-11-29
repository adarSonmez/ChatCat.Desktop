using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;

namespace ChatCat.Core.ViewModels.Concrete;

/// <summary>
/// A view model for the menu item
/// </summary>
public class MenuItemViewModel : BaseViewModel
{
    /// <summary>
    /// The text to display in the menu item
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// The type of the menu item
    /// </summary>
    public MenuItemType ItemType { get; set; }

    /// <summary>
    /// Unicode of the icon to display in the menu item
    /// </summary>
    public string? Icon { get; set; }
}