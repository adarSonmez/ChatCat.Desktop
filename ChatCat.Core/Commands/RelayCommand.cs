using System.Windows.Input;

namespace ChatCat.Core.Commands
{
    /// <summary>
    /// A command that relays its functionality to other objects by invoking delegates.
    /// </summary>
    /// <param name="execute">The delegate to execute when the command is executed.</param>
    /// <param name="canExecute">The delegate to determine if the command can be executed.</param>
    /// <remarks>Use this class to create a command that can be bound to a control in the view.</remarks>
    /// <exception cref="ArgumentNullException">Thrown when the execute delegate is null.</exception>
    public class RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null) : ICommand
    {
        #region Private Fields

        private readonly Predicate<object?>? _canExecute = canExecute;
        private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        #endregion Private Fields

        #region ICommand Implementation

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        #endregion ICommand Implementation
    }
}