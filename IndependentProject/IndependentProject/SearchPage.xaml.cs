using IndependentProject.Models;
using IndependentProject.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public List<TrackList> SearchResults { get; set; } = new List<TrackList>();
        public SharedData sharedData;

        public SearchPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sharedData = (SharedData)e.Parameter;
        }
    
        private void SearchByArtist_Click(object sender, RoutedEventArgs e)
        {
            SearchOptions.Content = "Artist";
        }

        private void SearchByTrack_Click(object sender, RoutedEventArgs e)
        {
            SearchOptions.Content = "Track";
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            String SearchTerm = SearchBox.Text;
            MusicSearchRootObject musicSearchRootObject = new MusicSearchRootObject();
            Retriever retriever = new Retriever();
            if(SearchOptions.Content.Equals("Select"))
            {
                WarningBlock.Text = "Please select a search option";
                return;
            }
            if (SearchTerm.Equals(""))
            {
                WarningBlock.Text = "Please enter a search term";
                return;
            }
            WarningBlock.Text = "";

            if (SearchOptions.Content.Equals("Artist"))
            {
                musicSearchRootObject = await retriever.GetTrackSearchResults(SearchTerm, false);
            }
            else
            {
                musicSearchRootObject = await retriever.GetTrackSearchResults(SearchTerm, true);
            }

            SearchResults = musicSearchRootObject.message.body.track_list;
            MusicSearchViewModel results = new MusicSearchViewModel();
            foreach(TrackList trackList in SearchResults)
            {
                MusicViewModel music = new MusicViewModel()
                {
                    TrackName = trackList.track.track_name,
                    TrackId = "" + trackList.track.track_id,
                    ArtistName = trackList.track.artist_name
                };
                results.Music.Add(music);
            }
            sharedData.Results = results;
            this.Frame.Navigate(typeof(ResultsPage), sharedData);
        }
    }
}