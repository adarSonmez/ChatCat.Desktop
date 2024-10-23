using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Desktop.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.Controls
{
    /// <summary>
    /// A base class for WPF user controls that provides ViewModel binding, loading, and unloading animations.
    /// </summary>
    /// <typeparam name="VM">The type of the ViewModel that this user control will bind to. The ViewModel must inherit from <see cref="BaseViewModel"/>.</typeparam>
    public class BaseControl<VM> : UserControl
        where VM : BaseViewModel, new()
    {
        private VM _viewModel = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControl{VM}"/> class.
        /// Sets up ViewModel binding and subscribes to the <see cref="UserControl.Loaded"/> and <see cref="UserControl.Unloaded"/> events.
        /// </summary>
        public BaseControl()
        {
            Loaded += BaseControl_Loaded;
            Unloaded += BaseControl_Unloaded;

            DataContext = _viewModel;
        }

        /// <summary>
        /// Gets or sets the ViewModel for this user control.
        /// When the ViewModel is set, it automatically updates the <see cref="FrameworkElement.DataContext"/> of the control.
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

        #region Control Animations

        /// <summary>
        /// Gets or sets the duration in seconds for the animations (both load and unload animations).
        /// The default value is 0.8 seconds.
        /// </summary>
        protected virtual float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// Gets or sets the type of animation that should play when the control is loaded.
        /// The default value is <see cref="FrameworkAnimationType.None"/>, meaning no animation will play.
        /// </summary>
        protected virtual FrameworkAnimationType ControlLoadAnimation { get; set; } = FrameworkAnimationType.None;

        /// <summary>
        /// Gets or sets the type of animation that should play when the control is unloaded.
        /// The default value is <see cref="FrameworkAnimationType.None"/>, meaning no animation will play.
        /// </summary>
        protected virtual FrameworkAnimationType ControlUnloadAnimation { get; set; } = FrameworkAnimationType.None;

        #endregion Control Animations

        #region Event Handlers

        /// <summary>
        /// Handles the <see cref="UserControl.Loaded"/> event and starts the defined load animation if applicable.
        /// </summary>
        /// <param name="sender">The event sender (this user control).</param>
        /// <param name="e">Event data.</param>
        private async void BaseControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ControlLoadAnimation != FrameworkAnimationType.None)
            {
                await this.BeginAnimationAsync(ControlLoadAnimation, SlideSeconds);
            }
        }

        /// <summary>
        /// Handles the <see cref="UserControl.Unloaded"/> event and starts the defined unload animation if applicable.
        /// </summary>
        /// <param name="sender">The event sender (this user control).</param>
        /// <param name="e">Event data.</param>
        private async void BaseControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (ControlUnloadAnimation != FrameworkAnimationType.None)
            {
                await this.BeginAnimationAsync(ControlUnloadAnimation, SlideSeconds);
            }
        }

        #endregion Event Handlers
    }
}