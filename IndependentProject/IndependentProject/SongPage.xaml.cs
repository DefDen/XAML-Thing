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
            if(sharedData.fromHistory)
            {
                SearchPageButton.Visibility = Visibility.Collapsed;
            }
        }

        //Sets up the TextBlocks on the page by getting the song information and lyrics from the MusixMatch API
        private async void SetInfoViewModelAsync(String trackId)
        {
            Retriever retriever = new Retriever();
            MusicFromIdRootObject music = await retriever.GetMusic(sharedData.CommonTrackId);
            LyricsRootObject lyrics = await retriever.GetLyrics(sharedData.TrackId);
            //Assigning TextBlock text to match song's info
            infoViewModel = new InfoViewModel()
            {
                AlbumName = music.message.body.track.album_name,
                TrackName = music.message.body.track.track_name,
                ArtistName = music.message.body.track.artist_name,
                LyricsString = lyrics.message.body.lyrics.lyrics_body,
            };
            Title.Text = infoViewModel.TrackName + " by " + infoViewModel.ArtistName;
            AlbumName.Text = "Album: " + infoViewModel.AlbumName;
            Lyrics.Text = infoViewModel.LyricsString;
            if(Lyrics.Text.Equals(""))
            {
                Lyrics.Text = "No lyrics available";
            }
            //Links to YT and Spotify
            YouTubeButton.NavigateUri = new Uri("https://www.youtube.com/results?search_query=" + Title.Text);
            SpotifyButton.NavigateUri = new Uri("https://open.spotify.com/search/results/" + Title.Text);
        }

        private void SearchPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage), sharedData);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(sharedData.fromHistory)
            {
                sharedData.fromHistory = false;
                this.Frame.Navigate(typeof(SearchPage), sharedData);
            }
            else
            {
                this.Frame.Navigate(typeof(ResultsPage), sharedData);
            }
        }
    }
}
