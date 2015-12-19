namespace Patuvalnik.ViewModels
{
    using System.Collections.Generic;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;

    public class TripsViewModel : BaseViewModel
    {
        private Dictionary<int, string> cities;

        private IDataProvider dp;

        private List<Trip> trips;

        public TripsViewModel(IDataProvider dataProvider, int from = 0, int to = 0)
        {
            this.dp = dataProvider;
            this.GetTripsAsync(from, to);
        }

        public Dictionary<int, string> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;

                if (this.trips != null)
                {
                    this.UpdateTripsWithCitiesNames();
                }
            }
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

                if (this.Cities != null)
                {
                    this.UpdateTripsWithCitiesNames();
                }
            }
        }

        private void UpdateTripsWithCitiesNames()
        {
            foreach (var trip in this.trips)
            {
                trip.FromCity = this.Cities[trip.From_city_id];
                trip.ToCity = this.Cities[trip.To_city_id];
            }

            this.NotifyPropertyChanged("Trips");
        }

        public async void GetTripsAsync(int from, int to)
        {
            if (this.trips == null)
            {
                var t = await this.dp.GetTrips(from, to);

                this.Trips = t;
            }
        }
    }
}