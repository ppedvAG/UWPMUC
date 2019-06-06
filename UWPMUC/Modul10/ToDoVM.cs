using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPMUC.Modul06;
using WebApplication1;

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
            ToDoListe = new ObservableCollection<ToDo>();
            
        }
        public ObservableCollection<ToDo> ToDoListe { get; set; }

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
            set { _NeuToDo = value;
                RaisePropertyChanged();
            }
        }
        public ICommand LoadCommand => new DelegateCommand(LoadTodo);
        public void LoadTodo()
        {
            var ef = new Model1();
           
            foreach (var item in ef.ToDo)
            {
                ToDoListe.Add(item);

            }


        }


        public ICommand SaveNeuCommand => new DelegateCommand(SaveNeuTodo);
        public void SaveNeuTodo()
        {
            var ef = new Model1();
            NeuToDo.Datum = DateTime.Now;
            if (ef.ToDo.Count() > 0)
            {
                var max = ef.ToDo.Max(x => x.Id);
                NeuToDo.Id = max + 1;
               
            }
            else NeuToDo.Id = 1;


            ef.ToDo.Add(NeuToDo);
            ef.SaveChanges();
            ToDoListe.Add(NeuToDo);
            
            NeuToDo = new ToDo();

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
