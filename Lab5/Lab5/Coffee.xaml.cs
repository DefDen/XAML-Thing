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

namespace Lab5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Coffee : Page
    {
        public Coffee()
        {
            this.InitializeComponent();
        }

        private Boolean roast = false;

        private void ShowCoffee(Boolean show)
        {
            if(show)
            {
                CoffeeRoast.Visibility = Visibility.Visible;
                CoffeeSweetener.Visibility = Visibility.Visible;
                CoffeeCream.Visibility = Visibility.Visible;
            }
            else
            {
                CoffeeRoast.Visibility = Visibility.Collapsed;
                CoffeeSweetener.Visibility = Visibility.Collapsed;
                CoffeeCream.Visibility = Visibility.Collapsed;
            }
        }

        private void CoffeeRoastNone_Click(object sender, RoutedEventArgs e)
        {
            roast = false;
            ShowCoffee(roast);
        }

        private void CoffeeRoastDark_Click(object sender, RoutedEventArgs e)
        {
            roast = true;
            CoffeeRoast.Text = "Dark";
            ShowCoffee(roast);
        }

        private void CoffeeRoastMedium_Click(object sender, RoutedEventArgs e)
        {
            roast = true;
            CoffeeRoast.Text = "Medium";
            ShowCoffee(roast);
        }

        private void CoffeeSweetenerNone_Click(object sender, RoutedEventArgs e)
        {
            CoffeeSweetener.Visibility = Visibility.Collapsed;
            CoffeeSweetener.Text = "";
        }

        private void CoffeeSweetenerSugar_Click(object sender, RoutedEventArgs e)
        {
            ShowCoffee(roast);
            CoffeeSweetener.Text = "Sugar";
        }

        private void CoffeeCreamNone_Click(object sender, RoutedEventArgs e)
        {
            CoffeeCream.Visibility = Visibility.Collapsed;
            CoffeeCream.Text = "";
        }

        private void CoffeeCreamMilk2_Click(object sender, RoutedEventArgs e)
        {
            ShowCoffee(roast);
            CoffeeCream.Text = "2% Milk";
        }

        private void CoffeeCreamMilkWhole_Click(object sender, RoutedEventArgs e)
        {
            ShowCoffee(roast);
            CoffeeCream.Text = "Whole Milk";
        }
    }
}
