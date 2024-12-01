using ChatCat.Core.Utils.IoC;
using ChatCat.Core.ViewModels.Concrete;

namespace ChatCat.Core.Utils.Locator;

/// <summary>
/// A locator class to resolve and locate core services.
/// </summary>
public class CoreLocator
{
    #region View Model Locatings

    public static ApplicationVM ApplicationVM => DependencyResolver.Resolve<ApplicationVM>()!;
    public static LoginPageVM LoginPageVM => DependencyResolver.Resolve<LoginPageVM>()!;
    public static RegisterPageVM RegisterPageVM => DependencyResolver.Resolve<RegisterPageVM>()!;
    public static ChatListVM ChatListVM => DependencyResolver.Resolve<ChatListVM>()!;
    public static ChatListItemVM ChatListItemVM => DependencyResolver.Resolve<ChatListItemVM>()!;
    public static ChatInputVM ChatInputVM => DependencyResolver.Resolve<ChatInputVM>()!;
    public static AttachmentMenuVM AttachmentMenuVM => DependencyResolver.Resolve<AttachmentMenuVM>()!;
    public static MenuItemVM MenuItemVM => DependencyResolver.Resolve<MenuItemVM>()!;
    public static MessageListVM MessageListVM => DependencyResolver.Resolve<MessageListVM>()!;
    public static MessageListItemVM MessageListItemVM => DependencyResolver.Resolve<MessageListItemVM>()!;

    #endregion View Model Locatings
}