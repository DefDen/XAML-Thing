using IndependentProject.Models;
using IndependentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if(sharedData.isAdvancedSearch)
            {
                AdvancedSearchArtist.Text = sharedData.AdvancedSearchBoxArtist;
                AdvancedSearchTrack.Text = sharedData.AdvancedSearchBoxTrack;
            }
            else
            {
                SearchBox.Text = sharedData.SearchBoxTerm;
                if(sharedData.isArtistSearch == true)
                {
                    SearchOptions.Content = "Artist";
                }
                else
                {
                    SearchOptions.Content = "Track";
                }
            }
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
            sharedData.isAdvancedSearch = false;
            sharedData.SearchBoxTerm = SearchBox.Text;

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
                sharedData.isArtistSearch = true;
                musicSearchRootObject = await retriever.GetTrackSearchResults(SearchTerm, "", false, false);
            }
            else
            {
                sharedData.isArtistSearch = false;
                musicSearchRootObject = await retriever.GetTrackSearchResults(SearchTerm, "", false, true);
            }

            sharedData.Music.Clear();
            sharedData.SearchTerm = SearchTerm;

            SearchResults = musicSearchRootObject.message.body.track_list;
            
            foreach (TrackList trackList in SearchResults)
            {
                MusicViewModel music = new MusicViewModel()
                {
                    TrackName = trackList.track.track_name,
                    TrackId = "" + trackList.track.track_id,
                    CommonTrackId = "" + trackList.track.commontrack_id,
                    ArtistName = trackList.track.artist_name
                };
                sharedData.Music.Add(music);
            }

            this.Frame.Navigate(typeof(ResultsPage), sharedData);
        }

        private async void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            sharedData.isAdvancedSearch = true;
            sharedData.AdvancedSearchBoxTrack = AdvancedSearchTrack.Text;
            sharedData.AdvancedSearchBoxArtist = AdvancedSearchArtist.Text;

            MusicSearchRootObject musicSearchRootObject = new MusicSearchRootObject();
            Retriever retriever = new Retriever();

            if(AdvancedSearchTrack.Text.Equals("") || AdvancedSearchArtist.Text.Equals(""))
            {
                sharedData.noArtistOrTrack = true;
                if (AdvancedSearchTrack.Text.Equals("") && AdvancedSearchArtist.Text.Equals(""))
                {
                    AdvancedWarningBlock.Text = "Please enter a search term";
                    return;
                }
            }
            else
            {
                sharedData.noArtistOrTrack = false;
            }

            AdvancedWarningBlock.Text = "";

            musicSearchRootObject = await retriever.GetTrackSearchResults(AdvancedSearchTrack.Text, AdvancedSearchArtist.Text, true, true);

            sharedData.Music.Clear();

            if(sharedData.noArtistOrTrack)
            {
                sharedData.SearchTerm = AdvancedSearchTrack.Text + AdvancedSearchArtist.Text;
            }
            else
            {
                sharedData.SearchTerm = AdvancedSearchTrack.Text + " by " + AdvancedSearchArtist.Text;
            }

            SearchResults = musicSearchRootObject.message.body.track_list;

            foreach (TrackList trackList in SearchResults)
            {
                MusicViewModel music = new MusicViewModel()
                {
                    TrackName = trackList.track.track_name,
                    TrackId = "" + trackList.track.track_id,
                    CommonTrackId = "" + trackList.track.commontrack_id,
                    ArtistName = trackList.track.artist_name
                };
                sharedData.Music.Add(music);
            }

            this.Frame.Navigate(typeof(ResultsPage), sharedData);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            sharedData.fromHistory = true;
            MusicViewModel music = (MusicViewModel)e.ClickedItem;
            ObservableCollection<MusicViewModel> r = new ObservableCollection<MusicViewModel>();
            sharedData.History.Insert(0, music);
            foreach (MusicViewModel musicViewModel in sharedData.History)
            {
                if (musicViewModel.TrackId != music.TrackId)
                {
                    r.Add(musicViewModel);
                }
            }
            sharedData.History.Clear();
            foreach (MusicViewModel musicViewModel in r)
            {
                sharedData.History.Add(musicViewModel);
            }
            sharedData.History.Insert(0, music);
            sharedData.TrackId = "" + music.TrackId;
            sharedData.CommonTrackId = "" + music.CommonTrackId;
            this.Frame.Navigate(typeof(SongPage), sharedData);
        }

        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {
            sharedData.History.Clear();
        }
    }
}