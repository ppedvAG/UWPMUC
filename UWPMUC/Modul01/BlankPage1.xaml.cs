using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace UWPMUC.Modul01
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            //kommentr

        }

        private async void Grid_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var fo = KnownFolders.PicturesLibrary;
            var p = fo.GetFilesAsync();
            var ap = ApplicationData.Current.LocalFolder;
            //    File.WriteAllText(@"c:\temp\hannes.txt","test");
            var ls = ApplicationData.Current.LocalFolder;
            if (await ls.TryGetItemAsync("letztesbild.txt") != null)
            {

                var lb = await ls.GetFileAsync("letztesbild.txt");
                var datei = await FileIO.ReadTextAsync(lb);

               var letztimg=await StorageFile.GetFileFromPathAsync(datei);

                var thumb = await letztimg.GetThumbnailAsync(ThumbnailMode.PicturesView, 200,
                       ThumbnailOptions.UseCurrentScale);
                var bmp = new BitmapImage();
                bmp.SetSource(thumb);
                img1.Source = bmp;
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            StorageFile sf = await picker.PickSingleFileAsync();
            if (sf != null)
            {
                var thumb = await sf.GetThumbnailAsync(ThumbnailMode.PicturesView, 200,
                    ThumbnailOptions.UseCurrentScale);
                var bmp = new BitmapImage();
                bmp.SetSource(thumb);
                img1.Source = bmp;

                var ls = ApplicationData.Current.LocalFolder;
                var d = await ls.CreateFileAsync("letztesbild.txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(d, sf.Path);


            }
        }
    }
}
