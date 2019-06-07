using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace UWPMUC.Modul10
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage6 : Page
    {
       
        public MyClass MyProp { get; set; }
        public BlankPage6()
        {
            this.InitializeComponent();
            //this.Bindings.Update(); auch onetime
        }
    }
    public class MyClass 
    {
        private DateTime? _Datum;

        public DateTime? Datum
        {
            get { return _Datum; }
            set { _Datum = value; }
        }
        public DateTimeOffset GetDatum()
        {
            return new DateTimeOffset(Datum.Value);
        }
        public void SetDatum(DateTimeOffset datum)
        {
            Datum = datum.DateTime;
        }


    }

}
