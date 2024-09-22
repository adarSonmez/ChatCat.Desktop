using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.AttachedProperties
{
    /// <summary>
    /// Provides attached properties for <see cref="Button"/> controls.
    /// This class includes functionality to disable a button when it is marked as 'busy'.
    /// </summary>
    public class ButtonAttachedProperties
    {
        #region Dependency Properties

        /// <summary>
        /// Identifies the IsBusy attached property. When set to true, the button will be disabled;
        /// when false, the button will be enabled.
        /// </summary>
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.RegisterAttached(
            "IsBusy",
            typeof(bool),
            typeof(ButtonAttachedProperties),
            new PropertyMetadata(false, OnIsBusyChanged));

        #endregion Dependency Properties

        #region Event Handlers

        /// <summary>
        /// Handles changes to the <see cref="IsBusyProperty"/>.
        /// Disables or enables the button based on the new value.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject"/> (expected to be a <see cref="Button"/>).</param>
        /// <param name="e">Provides data about the property change, including old and new values.</param>
        private static void OnIsBusyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button btn)
            {
                // Disable the button when IsBusy is true, enable when false
                btn.IsEnabled = !(bool)e.NewValue;
            }
        }

        #endregion Event Handlers

        #region Setters and Getters

        /// <summary>
        /// Gets the value of the <see cref="IsBusyProperty"/> for the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">The object from which to read the IsBusy value.</param>
        /// <returns>A boolean value indicating whether the button is busy.</returns>
        public static bool GetIsBusy(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBusyProperty);
        }

        /// <summary>
        /// Sets the value of the <see cref="IsBusyProperty"/> for the given <see cref="DependencyObject"/>.
        /// This will enable or disable the button based on the value.
        /// </summary>
        /// <param name="obj">The object on which to set the IsBusy value.</param>
        /// <param name="value">True to mark the button as busy (disabled), false to mark it as not busy (enabled).</param>
        public static void SetIsBusy(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBusyProperty, value);
        }

        #endregion Setters and Getters
    }
}