using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatCat.Desktop.ViewModels.Base
{
    /// <summary>
    /// Base view model class that implements the INotifyPropertyChanged interface.
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        private volatile PropertyChangedEventHandler? _propertyChanged;

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

        /// <summary>
        /// Raises the PropertyChanged event for the specified property name.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed. This is optional and will be automatically provided by the compiler if not specified.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // Capture a local reference to ensure thread-safety
            PropertyChangedEventHandler? handler;
            lock (this)
            {
                handler = _propertyChanged;
            }

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}