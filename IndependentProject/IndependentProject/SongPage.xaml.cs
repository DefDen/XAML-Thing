using IndependentProject.Models;
using IndependentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongPage : Page
    {
        SharedData sharedData;
        InfoViewModel infoViewModel;

        public SongPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sharedData = (SharedData)e.Parameter;
            SetInfoViewModelAsync(sharedData.TrackId);
        }

        private async void SetInfoViewModelAsync(String trackId)
        {
            Retriever retriever = new Retriever();
            MusicFromIdRootObject music = await retriever.GetMusic(sharedData.CommonTrackId);
            LyricsRootObject lyrics = await retriever.GetLyrics(sharedData.TrackId);
            infoViewModel = new InfoViewModel()
            {
                AlbumName = music.message.body.track.album_name,
                TrackName = music.message.body.track.track_name,
                ArtistName = music.message.body.track.artist_name,
                LyricsString = lyrics.message.body.lyrics.lyrics_body
            };
            Title.Text = infoViewModel.TrackName + " by " + infoViewModel.ArtistName;
        }
    }
}
