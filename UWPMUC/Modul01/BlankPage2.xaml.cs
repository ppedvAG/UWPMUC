using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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

namespace UWPMUC.Modul01
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();
        }

        Geolocator geo;
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var status = await Geolocator.RequestAccessAsync();


            switch (status)
            {
                case GeolocationAccessStatus.Unspecified:
                    break;
                case GeolocationAccessStatus.Allowed:
                    geo = new Geolocator();
                    geo.StatusChanged += Geo_StatusChanged;
                    geo.PositionChanged += Geo_PositionChanged;
                    break;
                case GeolocationAccessStatus.Denied:
                    break;
                default:
                    break;
            }

        }

        private async void Geo_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                text1.Text = args.Position.Coordinate.Point.Position.Latitude + ":" +
                     args.Position.Coordinate.Point.Position.Longitude;
            }
            );



        }

        private void Geo_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            switch (args.Status)
            {
                case PositionStatus.Ready:

                    break;
                case PositionStatus.Initializing:
                    break;
                case PositionStatus.NoData:
                    break;
                case PositionStatus.Disabled:
                    break;
                case PositionStatus.NotInitialized:
                    break;
                case PositionStatus.NotAvailable:
                    break;
                default:
                    break;
            }
        }
    }
}
