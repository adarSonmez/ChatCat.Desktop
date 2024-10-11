using ChatCat.Core.ViewModels;
using System.Windows.Controls;

namespace ChatCat.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for ChatListControl.xaml
    /// </summary>
    public partial class ChatListControl : UserControl
    {
        public ChatListControl()
        {
            InitializeComponent();

            DataContext = new ChatListVM
            {
                Items =
                [
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 3,
                        IsSelected = true
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "JG",
                        UserName = "John",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 1,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "JG",
                        UserName = "John",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 12,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "LM",
                        UserName = "Luke",
                        LastMessage = "This chat app is awesome!",
                        NewMessageCount = 0,
                        IsSelected = false
                    },
                    new ChatListItemVM
                    {
                        Initials = "NO",
                        UserName = "Nina",
                        LastMessage = "I'm so excited to learn more about MVVM!",
                        NewMessageCount = 0,
                        IsSelected = false
                    }
                ]
            };
        }
    }
}