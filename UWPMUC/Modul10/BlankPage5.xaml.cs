using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebApplication1;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace UWPMUC.Modul10
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage5 : Page
    {
        public ToDoVMCompiled MyVM { get; set; } = new ToDoVMCompiled();

        public BlankPage5()
        {
            this.InitializeComponent();
        }

        private void SwipeItem_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {

        }

        private void SwipeItem_Invoked_1(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {

        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((CheckBox)sender).Tag.ToString());
            var item = MyVM.ToDoListe.Where(x => x.Id == id).First();
            MyVM.ToDoListe.Remove(item);

            var ef = new Model1();
            ef.ToDo.Remove(item);
            ef.SaveChanges();
        }

        private void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
        {
            var dlg = new MessageDialog("Hallo");
            dlg.ShowAsync();
        }
    }
}
