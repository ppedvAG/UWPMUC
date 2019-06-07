using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace UWPMUC.Modul11
{
    public sealed partial class MyUserControl1 : UserControl
    {
        private string _HannesText;

        public string HannesText
        {
            get { return _HannesText; }
            set { _HannesText = value;
                text1.Text = value;
            }
        }

        public MyUserControl1()
        {
            this.InitializeComponent();
        }
    }
}
