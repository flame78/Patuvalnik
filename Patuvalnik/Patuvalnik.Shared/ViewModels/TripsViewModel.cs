using Patuvalnik.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.ViewModels
{
    using Patuvalnik.REST;
    using System.Threading.Tasks;

    public class TripsViewModel : BaseViewModel
    {
        private Task<List<Trip>> trips;

        private VrumDataProvider dp;

        public TripsViewModel()
        {
            dp=new VrumDataProvider();
            
        }

        public Task<List<Trip>> Trips {  get
            {
                if (this.trips==null)
                {
                    this.trips = this.dp.GetInformation();
                }
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
