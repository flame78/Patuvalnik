 // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Patuvalnik
{
    using System;

    using Windows.Devices.Geolocation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Geolocator geolocator;

        public MainPage()
        {
            this.InitializeComponent();

            //    this.geolocator = new Geolocator();
            //    this.geolocator.PositionChanged += OnGeolocationPositionchanged;
        }

        private async void InitGeolocation()
        {
            var geoPosition = await geolocator.GetGeopositionAsync();
            //  geoPosition.
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

        private void OnGeolocationPositionchanged(Geolocator sender, PositionChangedEventArgs args)
        {
            this.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                    {
                        var lat = args.Position.Coordinate.Latitude;
                        var lon = args.Position.Coordinate.Longitude;
                    });
        }
    }
}