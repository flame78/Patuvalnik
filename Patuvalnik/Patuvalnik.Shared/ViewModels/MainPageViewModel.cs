namespace Patuvalnik.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;
    using Patuvalnik.REST;
    using Patuvalnik.Commands;
    using Windows.Devices.Geolocation;
    using System.Threading.Tasks;
    using System.Windows.Input;
    public class MainPageViewModel : BaseViewModel
    {
        private IDataProvider dataProvider;
        private List<City> cities;
        private TripsViewModel tripsFromTo;
        private City fromCity;
        private City toCity;

        private ICommand commandUseCurrentLocation;
        public string DisplayName { get; set; }



        public MainPageViewModel()
        {
            this.cities = new List<City>();
            this.dataProvider = new VrumDataProvider();
            this.TripsFromTo = new TripsViewModel();
            this.TripsToFrom = new TripsViewModel();
            this.TripsFrom = new TripsViewModel();
            this.TripsTo = new TripsViewModel();

            this.GetDataAsync();
        }

        public City FromCity
        {
            get
            {
                return this.fromCity;
            }
            set
            {
                this.fromCity = value;
                this.GetDataAsync();
                NotifyPropertyChanged("FromCity");
            }
        }
        public City ToCity
        {
            get
            {
                return this.toCity;
            }
            set
            {
                this.toCity = value;
                this.GetDataAsync();
                NotifyPropertyChanged("ToCity");

            }
        }

        public TripsViewModel TripsFromTo { get; set; }

        public TripsViewModel TripsToFrom { get; set; }

        public TripsViewModel TripsFrom { get; set; }

        public TripsViewModel TripsTo { get; set; }

        public List<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
                this.NotifyPropertyChanged("Cities");
            }
        }

        public ICommand UseCurrentLocation
        {
            get
            {
                if (this.commandUseCurrentLocation == null)
                {
                    this.commandUseCurrentLocation =
                        new RelayCommand(this.PerformUseCurrentLocation);
                }
                return this.commandUseCurrentLocation;
            }

        }

        private async void PerformUseCurrentLocation()
        {
            var geoPosition = await this.InitGeolocationAsync();

            double minDistance = double.MaxValue;

            City closestCity = new City();

            foreach (var city in Cities)
            {
                var currentDistance = CalculateDistance(geoPosition.Coordinate.Latitude, geoPosition.Coordinate.Longitude, city.Lat, city.Lng);
                if (minDistance > currentDistance)
                {
                    minDistance = currentDistance;
                    closestCity = city;
                }
            }

            this.FromCity = closestCity;
        }

        private double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance;

            double distanceX = x1 - x2;
            double distanceY = y1 - y2;

            distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }

        private async void GetDataAsync()
        {
            if (this.Cities.Count == 0)
            {
                var cs = await this.dataProvider.GetCities();
                this.Cities = cs;
            }
            var cities = this.Cities.ToDictionary(city => city.Id, city => city.Name);

            if (ToCity == null)
            {
                this.ToCity = this.Cities[2];
            }
            if (FromCity == null)
            {
                this.FromCity = this.Cities[1];
            }
            this.TripsFromTo.Trips = await GetTripsAsync(cities, FromCity.Id, ToCity.Id);
            this.TripsToFrom.Trips = await GetTripsAsync(cities, ToCity.Id, FromCity.Id);
            this.TripsFrom.Trips = await GetTripsAsync(cities, FromCity.Id, 0);
            this.TripsTo.Trips = await GetTripsAsync(cities, 0, ToCity.Id);
        }


        private async Task<List<Trip>> GetTripsAsync(Dictionary<int, string> cities, int from, int to)
        {
            var trips = await this.dataProvider.GetTrips(from, to);

            foreach (var trip in trips)
            {
                trip.FromCity = cities[trip.From_city_id];
                trip.ToCity = cities[trip.To_city_id];
            }
            return trips;
        }

        private async Task<Geoposition> InitGeolocationAsync()
        {
            var geolocator = new Geolocator();
            var geoPosition = await geolocator.GetGeopositionAsync();
            return geoPosition;
        }
    }
}