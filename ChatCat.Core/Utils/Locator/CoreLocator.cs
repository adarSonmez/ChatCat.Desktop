using ChatCat.Core.Utils.IoC;
using ChatCat.Core.ViewModels.Concrete;

namespace ChatCat.Core.Utils.Locator;

/// <summary>
/// A locator class to resolve and locate core services.
/// </summary>
public class CoreLocator
{
    #region View Model Locatings

    public static ApplicationVM ApplicationVM => ResolveViewModel<ApplicationVM>();
    public static LoginPageVM LoginPageVM => ResolveViewModel<LoginPageVM>();
    public static RegisterPageVM RegisterPageVM => ResolveViewModel<RegisterPageVM>();
    public static ChatListVM ChatListVM => ResolveViewModel<ChatListVM>();
    public static ChatListItemVM ChatListItemVM => ResolveViewModel<ChatListItemVM>();
    public static ChatInputVM ChatInputVM => ResolveViewModel<ChatInputVM>();
    public static AttachmentMenuVM AttachmentMenuVM => ResolveViewModel<AttachmentMenuVM>();
    public static MenuItemVM MenuItemVM => ResolveViewModel<MenuItemVM>();
    public static MessageListVM MessageListVM => ResolveViewModel<MessageListVM>();
    public static MessageListItemVM MessageListItemVM => ResolveViewModel<MessageListItemVM>();

    #endregion View Model Locatings

    /// <summary>
    /// Resolves a view model of type T. If the application is in design mode, it returns a new instance of T.
    /// Otherwise, it uses the DependencyResolver to resolve the view model.
    /// </summary>
    /// <typeparam name="T">The type of the view model to resolve.</typeparam>
    /// <returns>An instance of the view model of type T.</returns>
    protected static T ResolveViewModel<T>() where T : class, new()
    {
        return SharedObject.InDesignMode ? new T() : DependencyResolver.Resolve<T>()!;
    }
}