using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xakpc.BlazorBits.Bootstrap
{
    /// <summary>
    /// Very primitive simple generic command
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;

        public Command(Action<T> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(T parameter)
        {                   
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        public void Execute(T parameter)
        {
            _action.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }
    }
}
