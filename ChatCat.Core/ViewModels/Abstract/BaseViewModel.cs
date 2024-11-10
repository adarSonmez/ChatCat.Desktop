using ChatCat.Core.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ChatCat.Core.ViewModels.Abstract
{
    /// <summary>
    /// Base view model class that implements the <see cref="INotifyPropertyChanged"/> interface to support data binding in WPF applications.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Lock object used to ensure thread-safety when checking and updating property values.
        /// </summary>
        private readonly object _propertyValueCheckLock = new();

        /// <summary>
        /// Backing field for the <see cref="PropertyChanged"/> event handler.
        /// This ensures the handler is managed in a thread-safe manner.
        /// </summary>
        private volatile PropertyChangedEventHandler? _propertyChanged;

        #endregion Fields

        #region INotifyPropertyChanged Implementation

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                lock (this)
                {
                    _propertyChanged += value;
                }
            }
            remove
            {
                lock (this)
                {
                    _propertyChanged -= value;
                }
            }
        }

        #endregion INotifyPropertyChanged Implementation

        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for a given property.
        /// This method is typically called within property setters to notify the UI of a change.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed. Automatically provided if not explicitly specified due to <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler? handler;
            lock (this)
            {
                handler = _propertyChanged;
            }

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Event Handlers

        #region Public Properties

        /// <summary>
        /// Gets or sets a flag indicating if design-time data should be shown in the UI.
        /// </summary>
        public bool ShowDesignTimeData { get; set; } = true;

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Executes a command asynchronously, ensuring it cannot be run if the <paramref name="updatingFlag"/> is true.
        /// </summary>
        /// <typeparam name="T">The return type of the asynchronous operation.</typeparam>
        /// <param name="updatingFlag">An expression that evaluates to a boolean flag indicating if the command is currently executing.</param>
        /// <param name="action">The asynchronous action to execute.</param>
        /// <param name="defaultValue">The default value to return if the command cannot be executed.</param>
        /// <returns>The result of the asynchronous operation, or the default value if the command is already running.</returns>
        protected async Task<T?> RunCommandAsync<T>(Expression<Func<bool>> updatingFlag, Func<Task<T?>> action, T? defaultValue = default)
        {
            // Ensure thread-safety when checking and updating the flag
            lock (_propertyValueCheckLock)
            {
                // If the command is already executing, return the default value
                if (updatingFlag.GetPropertyValue())
                    return defaultValue;

                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                return await action();
            }
            finally
            {
                // Reset the flag to indicate the command has completed
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion Protected Methods
    }
}