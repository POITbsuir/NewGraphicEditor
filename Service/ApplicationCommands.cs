using System;
using System.Windows.Input;


namespace NewGraphicEditor.Service
{
    public class ApplicationCommands : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object param)
        {
            return this._canExecute == null || this._canExecute(param);
        }

        public void Execute(object param)
        {
            this._execute(param);
        }
        public ApplicationCommands(Action<object> _execute, Func<object, bool> _canExecute = null)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
        }
    }
}
