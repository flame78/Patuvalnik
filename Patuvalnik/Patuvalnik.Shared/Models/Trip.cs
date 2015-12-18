using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public int Facebook_trip_id { get; set; }

        public int Driver_profile_id { get; set; }

        public int? Car_id { get; set; }

        public int? Route_id { get; set; }

        public int From_city_id { get; set; }

        public int To_city_id { get; set; }

        public DateTime Start_time { get; set; }

        public DateTime End_time { get; set; }

        public string Status { get; set; }

        public string Confirm_type { get; set; }

        public DateTime? Trip_time { get; set; }

        public int Seats { get; set; }

        public int Seats_left { get; set; }

        public decimal? Price { get; set; }

        public DriverProfile Driver_profile { get; set; }
    }
}
