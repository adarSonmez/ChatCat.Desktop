using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Desktop.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// An generic base class for WPF pages that provides ViewModel binding and page animations on load and unload.
    /// </summary>
    /// <typeparam name="VM">The type of the ViewModel that this page will bind to. The ViewModel must inherit from <see cref="BaseViewModel"/>.</typeparam>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        private VM _viewModel = new();

        #region Constructors

        public BasePage()
        {
            DataContext = _viewModel;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the ViewModel for this page.
        /// When the ViewModel is set, it automatically updates the <see cref="FrameworkElement.DataContext"/> of the page.
        /// </summary>
        public VM ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;

                DataContext = _viewModel;
            }
        }

        #endregion Public Properties
    }

    /// <summary>
    /// A base class for WPF pages that provides page animations on load and unload.
    /// </summary>
    public class BasePage : Page
    {
        #region Constructors

        public BasePage()
        {
            Loaded += BasePage_Loaded;
            Unloaded += BasePage_Unloaded;
        }

        #endregion Constructors

        #region Page Animations

        protected virtual float SlideSeconds { get; set; } = 0.8f;
        protected virtual FrameworkAnimationType PageLoadAnimation { get; set; } = FrameworkAnimationType.None;
        protected virtual FrameworkAnimationType PageUnloadAnimation { get; set; } = FrameworkAnimationType.None;

        #endregion Page Animations

        #region Event Handlers

        /// <summary>
        /// Handles the <see cref="Page.Loaded"/> event and starts the defined load animation if applicable.
        /// </summary>
        /// <param name="sender">The event sender (this page).</param>
        /// <param name="e">Event data.</param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (PageLoadAnimation != FrameworkAnimationType.None)
            {
                Visibility = Visibility.Collapsed;
                await this.BeginAnimationAsync(PageLoadAnimation, SlideSeconds);
            }
        }

        /// <summary>
        /// Handles the <see cref="Page.Unloaded"/> event and starts the defined unload animation if applicable.
        /// </summary>
        /// <param name="sender">The event sender (this page).</param>
        /// <param name="e">Event data.</param>
        private async void BasePage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (PageUnloadAnimation != FrameworkAnimationType.None)
            {
                Visibility = Visibility.Visible;
                await this.BeginAnimationAsync(PageUnloadAnimation, SlideSeconds);
            }
        }

        #endregion Event Handlers
    }
}