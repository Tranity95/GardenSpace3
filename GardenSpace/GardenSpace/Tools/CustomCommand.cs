using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GardenSpace.Tools
{
    public class CustomCommand: ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public CustomCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public CustomCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
    //public class CustomCommand<T> : ICommand
    //{
    //    Action<T> action;
    //    public CustomCommand(Action<T> action)
    //    {
    //        this.action = action;
    //    }
    //    public event EventHandler CanExecuteChanged;
    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }
    //    public void Execute(object parameter)
    //    {
    //        action((T)parameter);
    //    }
    //}
}
