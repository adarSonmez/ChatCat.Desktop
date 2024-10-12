﻿using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Concrete.Chat;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatPageVM>
    {
        public ChatPage()
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromLeft;
            PageUnloadAnimation = PageAnimation.SlideAndFadeOutToLeft;

            InitializeComponent();
        }
    }
}