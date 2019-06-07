using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPMUC.Modul06;
using WebApplication1;
using Windows.UI.Xaml.Input;

namespace UWPMUC.Modul10
{
 public   class ToDoVMCompiled : INotifyPropertyChanged
    {
        public ToDoVMCompiled()
        {
          
            _NeuToDo = new ToDo();
            ToDoListe = new ObservableCollection<ToDo>();

        }
        public ObservableCollection<ToDo> ToDoListe { get; set; }

        private ToDo _NeuToDo;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ToDo NeuToDo
        {
            get { return _NeuToDo; }
            set
            {
                _NeuToDo = value;
                RaisePropertyChanged();
            }
        }
        
        public void LoadTodo()
        {
            var ef = new Model1();

            foreach (var item in ef.ToDo)
            {
                ToDoListe.Add(item);

            }


        }
        public void CheckedTodo()
        {
        }


            public void SaveNeuTodo()
        {
            var ret=FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
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
}
