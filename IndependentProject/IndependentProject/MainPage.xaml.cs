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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MusicSearchViewModel SearchViewModel { get; set; } = new MusicSearchViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            InnerFrame.Navigate(typeof(SearchPage));
        }

        public async Task GetSearchResultsByTrack(String term, bool isTrackSearch)
        {
            Retriever retriever = new Retriever();
            MusicSearchRootObject musicSearchRoot = await retriever.GetTrackSearchResults(term, isTrackSearch);
            MusicSearchViewModel musicSearchViewModel = new MusicSearchViewModel();

            SearchViewModel.Music.Clear();

            foreach (Models.TrackList trackList in musicSearchRoot.message.body.track_list)
            {
                MusicViewModel music = new MusicViewModel()
                {
                    TrackName = trackList.track.track_name,
                    TrackId = "" + trackList.track.track_id,
                    ArtistName = trackList.track.artist_name,
                };
                musicSearchViewModel.Music.Add(music);
            }
        }
    }
}
