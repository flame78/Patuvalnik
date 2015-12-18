using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.ViewModels
{
    public class MainPageViewModel
    {
        public TripsViewModel TripsFromTo { get; set; }
        public TripsViewModel TripsToFrom { get; set; }
        public TripsViewModel TripsFrom { get; set; }
        public TripsViewModel TripsTo { get; set; }

        public MainPageViewModel()
        {
            TripsFromTo = new TripsViewModel(1, 2);
            TripsToFrom =  new TripsViewModel(2,1);
            TripsFrom = new TripsViewModel(1, 0);
            TripsTo = new TripsViewModel(0, 2);
        }

    }
}
