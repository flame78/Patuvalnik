using Patuvalnik.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.ViewModels
{
    public class TripsViewModel : BaseViewModel
    {
        private List<Trip> trips;

        public List<Trip> Trips {  get
            {
                return this.trips;
            }
            set
            {
                if (this.trips == value) return;
                this.trips = value;
                NotifyPropertyChanged("Trips");
            }
        }
    }
}
