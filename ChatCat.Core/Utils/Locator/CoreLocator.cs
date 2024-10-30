using ChatCat.Core.Utils.IoC;
using ChatCat.Core.ViewModels.Concrete.Application;
using ChatCat.Core.ViewModels.Concrete.Auth;
using ChatCat.Core.ViewModels.Concrete.Chat;

namespace ChatCat.Core.Utils.Locator
{
    /// <summary>
    /// A locator class to resolve and locate core services.
    /// </summary>
    public class CoreLocator
    {
        #region View Model Locatings

        public static ApplicationVM ApplicationVM => DependencyResolver.Resolve<ApplicationVM>()!;
        public static ChatListVM ChatListVM => DependencyResolver.Resolve<ChatListVM>()!;
        public static LoginPageVM LoginPageVM => DependencyResolver.Resolve<LoginPageVM>()!;
        public static RegisterPageVM RegisterPageVM => DependencyResolver.Resolve<RegisterPageVM>()!;

        #endregion View Model Locatings
    }
}