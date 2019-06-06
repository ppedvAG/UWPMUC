using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPMUC.Modul06;

namespace UWPMUC.Modul10
{
    class ToDoVM
    {
        public ToDoVM()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                ID = 100;
            }
            
        }
        public int ID { get; set; }

        private ToDo _NeuToDo;

        public ToDo NeuToDo
        {
            get { return _NeuToDo; }
            set { _NeuToDo = value; }
        }
        
        public ICommand SaveNeuCommand => new DelegateCommand(SaveNeuTodo);
        public void SaveNeuTodo()
        {

        }

    }

    internal class DelegateCommand : ICommand
    {
        private Action _mycommand;

        public DelegateCommand(Action mycommand)
        {
            this._mycommand = mycommand;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mycommand();
        }
    }
}
