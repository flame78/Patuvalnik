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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Patuvalnik
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

        private void FeedButtonClick(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = true;
        }

        private void UseCurrentLocation(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = false;
        }

        private void RateDriver(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = false;
        }

        private void ChangeCitiesButtonClick(object sender, RoutedEventArgs e)
        {
            this.ChangeCitiesDropDown.IsOpen = true;
        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            this.OptionsDropDown.IsOpen = true;
        } 
    }
}
