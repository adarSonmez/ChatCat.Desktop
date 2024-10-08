﻿using ChatCat.Desktop.ViewModels.Base;

namespace ChatCat.Desktop.ViewModels
{
    public class ChatListItemVM : BaseViewModel
    {
        #region Public Properties

        public string UserName { get; set; }

        public string LastMessage { get; set; }

        public string Initials { get; set; }

        // public string ProfilePictureRGB { get; set; }

        public bool IsSelected { get; set; }

        public int NewMessageCount { get; set; }

        #endregion Public Properties
    }
}