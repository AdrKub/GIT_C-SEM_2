using System;
using System.Windows.Input;

namespace _20_MvvmFramework
{
    // http://docs.telerik.com/data-access/quick-start-scenarios/wpf/quickstart-wpf-viewmodelbase-and-relaycommand#implementing_relaycommand
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            // https://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
            // http://stackoverflow.com/questions/6634777/what-is-the-actual-task-of-canexecutechanged-and-commandmanager-requerysuggested

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action methodToExecute;
        private readonly Func<bool> canExecuteEvaluator;

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action methodToExecute) : this(methodToExecute, null)
        {
            // empty
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }
        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }
    }
}