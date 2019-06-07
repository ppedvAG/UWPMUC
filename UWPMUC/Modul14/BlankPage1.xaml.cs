using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace UWPMUC.Modul14
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vault = new PasswordVault();
            vault.Add(new PasswordCredential("login", "Hannes", "password"));

            var pwd=vault.Retrieve("login", "Hannes");

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
           IReadOnlyList<User> usr=await User.FindAllAsync();

          var ich=  User.GetFromId("WOwhX5WiEcSxlPWK0zpgytwG2PPErTGZtsrzXlh8+EQ=");
          var meinname=await  ich.GetPropertyAsync(KnownUserProperties.AccountName);
        }
    }
}
