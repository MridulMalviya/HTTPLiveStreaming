using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Library;
using Xamarin.Forms;

namespace HTTPLiveStreaming
{
    public partial class MainPage : ContentPage
    {
        readonly string HLS_URL1 = "http://live4.tdm.com.mo/ch1/_definst_/ch1.live/playlist.m3u8";
        readonly string HLS_URL2 = "https://devstreaming-cdn.apple.com/videos/streaming/examples/bipbop_16x9/bipbop_16x9_variant.m3u8";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CrossMediaManager.Current.MediaPlayer.AutoAttachVideoView = true;
            _ = PlayVideo();
        }

        private async Task PlayVideo()
        { 
            var item = await CrossMediaManager.Current.Extractor.CreateMediaItem(HLS_URL2);
            item.MediaType = MediaType.Hls;

            await CrossMediaManager.Current.Play(item);
        }
    }
}
