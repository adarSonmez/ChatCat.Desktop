using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChatCat.Desktop.AttachedProperties
{
    /// <summary>
    /// Provides attached properties for disabling frame navigation history in a <see cref="Frame"/>.
    /// </summary>
    public class DisableFrameHistoryAttachedProperties
    {
        #region Dependency Properties

        /// <summary>
        /// Identifies the DisableFrameHistory attached property.
        /// </summary>
        public static readonly DependencyProperty DisableFrameHistoryProperty = DependencyProperty.RegisterAttached(
            "DisableFrameHistory",
            typeof(bool),
            typeof(DisableFrameHistoryAttachedProperties),
            new PropertyMetadata(false, OnDisableFrameHistoryChanged));

        #endregion Dependency Properties

        #region Event Handlers

        /// <summary>
        /// Handles changes to the DisableFrameHistory attached property.
        /// </summary>
        /// <param name="d">The dependency object on which the property value changed.</param>
        /// <param name="e">Event data for the property change.</param>
        private static void OnDisableFrameHistoryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Frame frame)
            {
                if ((bool)e.NewValue)
                {
                    frame.Navigated += Frame_Navigated;
                }
                else
                {
                    frame.Navigated -= Frame_Navigated;
                }
            }
        }

        /// <summary>
        /// Handles the Navigated event of the Frame.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the event.</param>
        private static void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                frame.NavigationService.RemoveBackEntry();
            }
        }

        #endregion Event Handlers

        #region Setters and Getters

        public static bool GetDisableFrameHistory(DependencyObject obj) => (bool)obj.GetValue(DisableFrameHistoryProperty);

        public static void SetDisableFrameHistory(DependencyObject obj, bool value) => obj.SetValue(DisableFrameHistoryProperty, value);

        #endregion Setters and Getters
    }
}