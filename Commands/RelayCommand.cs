using System.Windows.Input;

namespace ChatCat.Desktop.Commands
{
    /// <summary>
    /// Represents a command that relays its functionality to delegates.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        private readonly Predicate<object?>? canExecute;
        private readonly Action<object?> execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The delegate to execute when the command is executed.</param>
        /// <param name="canExecute">The delegate to determine if the command can be executed.</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}