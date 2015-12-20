namespace Patuvalnik.ViewModels
{
    using System.Collections.Generic;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;

    public class TripsViewModel : BaseViewModel
    {
        private List<Trip> trips;

        public List<Trip> Trips
        {
            get
            {
                return this.trips;
            }
            set
            {
                this.trips = value;
       //         this.trips.Clear();
       //         this.trips.AddRange(value);
                this.NotifyPropertyChanged("Trips");
            }
        }

        public TripsViewModel()
        {
            this.trips = new List<Trip>();
        }
    }
}