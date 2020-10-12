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
        private readonly Func<T, bool> _canDoAction;

        public Command(Action<T> action, Func<T, bool> canDoAction = null)
        {
            _action = action;
            _canDoAction = canDoAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(T parameter)
        {
            return _canDoAction?.Invoke(parameter) ?? true;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute(parameter == null ? default : (T)parameter);
        }

        public void Execute(T parameter)
        {
            if (CanExecute(parameter))
                _action.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            Execute(parameter == null ? default : (T)parameter);
        }
    }
}
 