namespace Patuvalnik.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;
    using Patuvalnik.REST;
    using Windows.Devices.Geolocation;
    using System.Threading.Tasks;
    public class MainPageViewModel : BaseViewModel
    {
        private IDataProvider dataProvider;
        private List<City> cities;
        private TripsViewModel tripsFromTo;
        private City fromCity;
        private City toCity;

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
                NotifyPropertyChanged("FromCity");
            }
        }
        public City ToCity {
            get
            {
                return this.toCity;
            }
            set
            {
                this.toCity = value;
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
                this.FromCity = this.cities.First();
                this.ToCity = this.cities[2];
                this.NotifyPropertyChanged("Cities");
            }
        }

        private async void GetDataAsync()
        {
            this.Cities = await this.dataProvider.GetCities();
            var cities = this.Cities.ToDictionary(city => city.Id, city => city.Name);

            var geoPosition = await this.InitGeolocationAsync();

            this.TripsFromTo.Trips = await GetTripsAsync(cities, FromCity.Id, ToCity.Id);
            this.NotifyPropertyChanged("TripsFromTo");


            this.TripsToFrom.Trips = await GetTripsAsync(cities, ToCity.Id, FromCity.Id);
            this.NotifyPropertyChanged("TripsToFrom");


            this.TripsFrom.Trips = await GetTripsAsync(cities, FromCity.Id, 0);
            this.NotifyPropertyChanged("TripsFrom");

            this.TripsTo.Trips = await GetTripsAsync(cities, 0, ToCity.Id);
            this.NotifyPropertyChanged("TripsTo");
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