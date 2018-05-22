using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Book_MVVM_Step_3
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;//FUNC = Funktion mit Rückgabewert
        private readonly Action _execute;//ACTION = Funkion ohne Rückgabewerte

        public RelayCommand(Action execute) : this(execute, null) //Falls nur eine ACTION übergeben, wird der andere Konstruktor mit NULL aufgerufen
        {
        }

        public RelayCommand(Action execute, Func<bool> canexecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canexecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
