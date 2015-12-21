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

        public string Link { get; set; }

        public string ProfilePicture
        {
            get
            {
                return string.Format("http://graph.facebook.com/v2.5/{0}/picture", this.Fb_id);
            }
        }
    }
}
