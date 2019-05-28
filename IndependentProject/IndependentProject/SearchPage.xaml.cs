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
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void SearchByArtist_Click(object sender, RoutedEventArgs e)
        {
            SearchOptions.Content = "Artist";
        }

        private void SearchByTrack_Click(object sender, RoutedEventArgs e)
        {
            SearchOptions.Content = "Track";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String SearchTerm = SearchBox.Text;
            Retriever retriever = new Retriever();
            if(SearchOptions.Content.Equals("Artist"))
            {
                
            }
        }
    }
}
