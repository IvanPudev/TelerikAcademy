using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SquareIt.Commands
{
    public delegate void ExecuteDelegate();
    public delegate bool CanExecuteDelegate();

    class RelayCommand : ICommand
    {
        readonly ExecuteDelegate execute;
        readonly CanExecuteDelegate canExecute;

        public RelayCommand(ExecuteDelegate execute, CanExecuteDelegate canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
