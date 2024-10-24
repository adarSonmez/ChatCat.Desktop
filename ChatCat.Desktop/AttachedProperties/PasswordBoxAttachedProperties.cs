using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.AttachedProperties
{
    /// <summary>
    /// Provides attached properties for the <see cref="PasswordBox"/> control.
    /// </summary>
    public class PasswordBoxAttachedProperty
    {
        #region Dependency Properties

        /// <summary>
        /// Identifies the MonitorPasswordChanged attached property.
        /// </summary>
        public static readonly DependencyProperty MonitorPasswordProperty = DependencyProperty.RegisterAttached(
            "MonitorPassword",
            typeof(bool),
            typeof(PasswordBoxAttachedProperty),
            new PropertyMetadata(false, OnMonitorPasswordChangedChanged));

        /// <summary>
        /// Identifies the HasText attached property.
        /// </summary>
        public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached(
            "HasText",
            typeof(bool),
            typeof(PasswordBoxAttachedProperty),
            new PropertyMetadata(false));

        #endregion Dependency Properties

        #region Event Handlers

        /// <summary>
        /// Handles changes to the MonitorPasswordChanged attached property.
        /// </summary>
        /// <param name="d">The dependency object on which the property value changed.</param>
        /// <param name="e">Event data for the property change.</param>
        private static void OnMonitorPasswordChangedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                }
            }
        }

        /// <summary>
        /// Handles the PasswordChanged event of the PasswordBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the event.</param>
        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetHasText(passwordBox);
            }
        }

        #endregion Event Handlers

        #region Setters and Getters

        /// <summary>
        /// Gets the value of the MonitorPasswordChanged attached property.
        /// </summary>
        /// <param name="passwordBox">The object from which to read the MonitorPasswordChanged value.</param>
        /// <returns>A boolean value indicating whether the password is being monitored.</returns>
        public static bool GetMonitorPassword(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(MonitorPasswordProperty);
        }

        /// <summary>
        /// Sets the value of the MonitorPasswordChanged attached property.
        /// </summary>
        public static bool GetHasText(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(HasTextProperty);
        }

        /// <summary>
        /// Sets the value of the MonitorPasswordChanged attached property.
        /// </summary>
        public static void SetHasText(PasswordBox passwordBox)
        {
            passwordBox.SetValue(HasTextProperty, passwordBox.SecurePassword.Length > 0);
        }

        /// <summary>
        /// Sets the value of the MonitorPasswordChanged attached property.
        /// </summary>
        private static void SetMonitorPassword(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(MonitorPasswordProperty, value);
        }

        #endregion Setters and Getters
    }
}