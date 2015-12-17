namespace Patuvalnik.ViewModels
{
    using System.Collections.Generic;

    using Patuvalnik.Models;
    using Patuvalnik.REST;

    public class TripsViewModel : BaseViewModel
    {
        private VrumDataProvider dp;

        private List<Trip> trips;

        public int CityFrom { get; set; }

        public int CityTo { get; set; } 

        public TripsViewModel()
        {
            dp = new VrumDataProvider();
            this.GetTripsAsync();
        }


        public List<Trip> Trips
        {
            get
            {
                return this.trips;
            }
            set
            {
                if (this.trips == value)
                {
                    return;
                }
                this.trips = value;
                NotifyPropertyChanged("Trips");
            }
        }

        public async void GetTripsAsync()
        {
            if (this.trips == null)
            {
                var t = await this.dp.GetInformation();
                this.Trips = t;
            }
        }
    }
}