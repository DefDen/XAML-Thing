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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HambugerButton_Click(object sender, RoutedEventArgs e)
        {
            TheSplitView.IsPaneOpen = !TheSplitView.IsPaneOpen;
        }

        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShareListBoxItem.IsSelected)
            {
                InnerFrame.Navigate(typeof(BlankPage2));
                Title.Text = "Financial";
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (FavoritesListBoxItem.IsSelected)
            {
                InnerFrame.Navigate(typeof(BlankPage1));
                Title.Text = "Food";
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(typeof(BlankPage2));
            Title.Text = "Financial";
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
