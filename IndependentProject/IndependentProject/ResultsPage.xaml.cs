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
using IndependentProject.ViewModels;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultsPage : Page
    {
        public SharedData sharedData;

        public ResultsPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sharedData = (SharedData)e.Parameter;
            Title.Text = "Results for " + sharedData.SearchTerm;
            if(sharedData.Music.Count == 0)
            {
                NoResultsText.Visibility = Visibility.Visible;
            }
        }

        //Goes to the song page based on the song chosen and addes it to the history for future reference
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage), sharedData);
        }
    }
}
