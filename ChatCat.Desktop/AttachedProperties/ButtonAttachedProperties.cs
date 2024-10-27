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

        public static bool GetIsBusy(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBusyProperty);
        }

        public static void SetIsBusy(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBusyProperty, value);
        }

        #endregion Setters and Getters
    }
}