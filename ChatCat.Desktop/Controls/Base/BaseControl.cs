using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Abstract;
using ChatCat.Desktop.Extensions;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.Controls.Base
{
    /// <summary>
    /// A base class for WPF user controls that provides ViewModel binding, loading, and unloading animations.
    /// </summary>
    /// <typeparam name="VM">The type of the ViewModel that this user control will bind to. The ViewModel must inherit from <see cref="BaseViewModel"/>.</typeparam>
    public class BaseControl<VM> : BaseControl
        where VM : BaseViewModel, new()
    {
        #region Private Fields

        private VM _viewModel = new();

        #endregion Private Fields

        #region Constructors

        public BaseControl()
        {
            if (!InheritsDataContext)
            {
                DataContext = ViewModel;
            }
        }

        #endregion Constructors

        #region Public/Protected Properties

        /// <summary>
        /// The ViewModel that this user control will bind to.
        /// </summary>
        public VM ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;
                _viewModel.ShowDesignTimeData = false;
            }
        }

        /// <summary>
        /// Determines whether the control should inherit the DataContext from the parent control.
        /// </summary>
        ///<remarks>Default is <see langword="false"/>. Please override this property in derived classes to change the behavior.</remarks>
        protected virtual bool InheritsDataContext => false;

        #endregion Public/Protected Properties
    }

    /// <summary>
    /// A base class for WPF user controls that provides loading and unloading animations.
    /// </summary>
    public class BaseControl : UserControl
    {
        #region Constructors

        public BaseControl()
        {
            // Do not run animations in design mode
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            Loaded += BaseControl_Loaded;
            Unloaded += BaseControl_Unloaded;
        }

        #endregion Constructors

        #region Control Animations

        /// <summary>
        /// The duration of the slide animation when the control is loaded or unloaded.
        /// </summary>
        /// <remarks>Default is 0.8 seconds.</remarks>
        protected virtual float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The animation to play when the control is loaded.
        /// </summary>
        /// <remarks>Default is <see cref="FrameworkAnimationType.None"/>.</remarks>
        protected virtual FrameworkAnimationType ControlLoadAnimation { get; set; } = FrameworkAnimationType.None;

        /// <summary>
        /// The animation to play when the control is unloaded.
        /// </summary>
        /// <remarks>Default is <see cref="FrameworkAnimationType.None"/>.</remarks>
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