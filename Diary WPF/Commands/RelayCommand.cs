using System;
using System.Windows.Input;

namespace Diary_WPF.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        private Action<object> refreshStudent;



        public RelayCommand(ICommand refreshStudentCommand, Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> refreshStudent, Action<object> canRefreshStudents)
        {
            this.refreshStudent = refreshStudent;

        }

        public RelayCommand(Action<object> refreshStudent)
        {
            this.refreshStudent = refreshStudent;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
