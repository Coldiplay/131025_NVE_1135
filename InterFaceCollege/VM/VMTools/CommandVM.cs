using System.Windows.Input;

namespace InterFaceCollege.VM.VMTools
{
    public class CommandVM(Action action, Func<bool> canExecute) : ICommand
    {
        readonly Action action = action;
        readonly Func<bool> canExecute = canExecute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canExecute();
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
