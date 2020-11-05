using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tecsup.ViewModel
{
    class RelayCommand<T> : ICommand

    {
        #region Fields
        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;
        #endregion
        #region Constructor
        ///<summary>
        ///Initializes a new instances of <see cref="DelegateCommand{T}"/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.This</param>
        ///<remarks><seealso cref="CanExecute"/> will always returns true.</remarks>

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }
        ///<sumary>
        ///Create a new command.
        /// </sumary>
        /// <param name="execute">The execution logic</param>
        /// <param name="canExecute">The execution status logic.</param>

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
           
                if (execute == null)
                    throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
          
        }
        #endregion
        #region ICommand Members

        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }
        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        ///<sumary>
        ///Defines the method to be called whe the comand is invoked.
        /// </sumary>
        /// <param name="parameter">Data used by the command.If the command does not require data</param>
        
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion
    }
}
