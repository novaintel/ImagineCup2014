using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JamesPodcast.Win8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        MediaElement media;

        public MainPage()
        {
            media = new MediaElement();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SetLocalMedia();
            GetPodcast();
            media.Play();
        }

        async private void SetLocalMedia()
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".mp3");

            var file = await openPicker.PickSingleFileAsync();

            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            // mediaControl is a MediaElement defined in XAML
            if (null != file)
            {
                media.SetSource(stream, file.ContentType);
            }
        }

        async private void GetPodcast(){

            HttpClient client = new HttpClient();
            Uri url = new Uri("http://twit.cachefly.net/audio/ww/ww0351/ww0351.mp3");
            HttpResponseMessage response = await client.GetAsync(url);
        }

    }
}
