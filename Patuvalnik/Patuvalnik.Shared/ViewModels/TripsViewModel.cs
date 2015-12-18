namespace Patuvalnik.ViewModels
{
    using System.Collections.Generic;

    using Patuvalnik.Models;
    using Patuvalnik.REST;

    public class TripsViewModel : BaseViewModel
    {
        private VrumDataProvider dp;

        private List<Trip> trips;

     public TripsViewModel(int from=0, int to=0)
        {
            dp = new VrumDataProvider();
            this.GetTripsAsync(from, to);
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

        public async void GetTripsAsync(int from, int to)
        {
            if (this.trips == null)
            {
                var t = await this.dp.GetInformation(from, to);
                this.Trips = t;
            }
        }
    }
}