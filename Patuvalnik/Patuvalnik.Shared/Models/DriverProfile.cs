using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patuvalnik.Models
{
    public class DriverProfile
    {
        public User User { get; set; }

        public decimal? Rating { get; set; }

        public int? Ratings_count { get; set; }
    }
}