namespace Patuvalnik.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;
    using Patuvalnik.REST;

    public class MainPageViewModel : BaseViewModel
    {
        private IDataProvider dataProvider;

        public MainPageViewModel()
        {
            this.dataProvider = new VrumDataProvider();

            this.TripsFromTo = new TripsViewModel(this.dataProvider, 1, 2);
            this.TripsToFrom = new TripsViewModel(this.dataProvider, 2, 1);
            this.TripsFrom = new TripsViewModel(this.dataProvider, 1, 0);
            this.TripsTo = new TripsViewModel(this.dataProvider, 0, 2);
            this.GetCities();
        }

        public TripsViewModel TripsFromTo { get; set; }

        public TripsViewModel TripsToFrom { get; set; }

        public TripsViewModel TripsFrom { get; set; }

        public TripsViewModel TripsTo { get; set; }

        public List<City> Cities { get; set; }

        private async void GetCities()
        {
            this.Cities = await this.dataProvider.GetCities();

            var cities = this.Cities.ToDictionary(city => city.Id, city => city.Name);

            this.TripsFromTo.Cities = cities;
            this.TripsToFrom.Cities = cities;
            this.TripsFrom.Cities = cities;
            this.TripsTo.Cities = cities;
        }
    }
}