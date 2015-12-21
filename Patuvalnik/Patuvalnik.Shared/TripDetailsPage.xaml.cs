using Patuvalnik.Models;
using Patuvalnik.REST;
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
    public sealed partial class TripDetailsPage : Page
    {
        Trip DetailedTrip { get; set; }

        public TripDetailsPage()
        {

        }

        private void BackToFeed(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var dp = new VrumDataProvider();
            var tripId = (int)e.Parameter;
            var cs = await dp.GetCities();
            var cities = cs.ToDictionary(city => city.Id, city => city.Name);

            this.DetailedTrip = await dp.GetTripDetails(tripId);
            this.DetailedTrip.FromCity = cities[this.DetailedTrip.From_city_id];
            this.DetailedTrip.ToCity = cities[this.DetailedTrip.To_city_id];
      
            this.DataContext = DetailedTrip;
            this.InitializeComponent();

            // TODO : get det

        }

        private void JoinTrip(object sender, RoutedEventArgs e)
        {

        }
    }
}
