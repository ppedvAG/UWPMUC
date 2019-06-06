using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPMUC.Modul06;
using WebApplication1;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace UWPMUC.Modul7
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage3 : Page
    {
        public BlankPage3()
        {
            this.InitializeComponent();
        }
        Model1 ef = new Model1();
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var t = new ToDo();
            t.Aufgabe = text1.Text;
            t.Datum = DateTime.Now;
            t.Termin = DateTime.Now.AddDays(2);
            t.Bearbeiter = "pre";
            if (ef.ToDo.Count() > 0)
            {
                var max = ef.ToDo.Max(x => x.Id);
                t.Id = max+1;
                    //ef.ToDo.Last().Id + 1;
            }
            else t.Id = 1;
            
          
            ef.ToDo.Add(t);
            ef.SaveChanges();
            
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Liste1.ItemsSource = ef.ToDo.ToList();
        }
    }
}
