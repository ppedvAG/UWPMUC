﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPMUC.Modul06;

namespace UWPMUC.Modul10
{
    class ToDoVM:INotifyPropertyChanged
    {
        public ToDoVM()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                ID = 100;
            }
            _NeuToDo = new ToDo();
            
        }
        public int ID { get; set; }

        private ToDo _NeuToDo;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ToDo NeuToDo
        {
            get { return _NeuToDo; }
            set { _NeuToDo = value; }
        }
        
        public ICommand SaveNeuCommand => new DelegateCommand(SaveNeuTodo);
        public void SaveNeuTodo()
        {
            NeuToDo.Id++;
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
