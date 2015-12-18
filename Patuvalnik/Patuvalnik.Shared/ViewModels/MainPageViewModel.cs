using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.ViewModels
{
    using Patuvalnik.Contracts;
    using Patuvalnik.Models;
    using Patuvalnik.REST;

    public class MainPageViewModel
    {
        private IDataProvider dataProvider;

        public TripsViewModel TripsFromTo { get; set; }
        public TripsViewModel TripsToFrom { get; set; }
        public TripsViewModel TripsFrom { get; set; }
        public TripsViewModel TripsTo { get; set; }

        public List<City> Cities { get; set; }

        
        public MainPageViewModel()
        {
            this.dataProvider = new VrumDataProvider();
            this.GetCities();
            this.TripsFromTo = new TripsViewModel(this.dataProvider,  1, 2);
            this.TripsToFrom = new TripsViewModel(this.dataProvider, 2, 1);
            this.TripsFrom = new TripsViewModel(this.dataProvider, 1, 0);
            this.TripsTo = new TripsViewModel(this.dataProvider, 0, 2);

            
        }

        private async void GetCities()
        {
            this.Cities = await this.dataProvider.GetCities();
        }

    }
}
