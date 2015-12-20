using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patuvalnik.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string         LocalizedName{ get; set; }

        public int Priority { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public double Radius { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
