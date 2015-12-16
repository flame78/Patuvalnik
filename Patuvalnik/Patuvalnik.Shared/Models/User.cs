using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patuvalnik.Models
{
    public class User
    {
        public int Id { get; set; }

        public ulong Fb_id { get; set; }

        public ulong? Real_fb_id { get; set; }

        public string Name { get; set; }
    }
}
