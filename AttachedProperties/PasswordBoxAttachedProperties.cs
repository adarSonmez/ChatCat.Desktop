using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.AttachedProperties
{
    /// <summary>
    /// Provides attached properties for the <see cref="PasswordBox"/> control.
    /// </summary>
    internal class PasswordBoxAttachedProperty
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

        public static void SetMonitorPassword(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(MonitorPasswordProperty, value);
        }

        public static bool GetMonitorPassword(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(MonitorPasswordProperty);
        }

        public static bool GetHasText(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(HasTextProperty);
        }

        private static void SetHasText(PasswordBox passwordBox)
        {
            passwordBox.SetValue(HasTextProperty, passwordBox.SecurePassword.Length > 0);
        }

        #endregion Setters and Getters
    }
}