using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patuvalnik.Models
{
    [Table("KeyStringData")]
    public class KeyString
    {
        [PrimaryKey]
        public string Key { get; set; }

        public string Str { get; set; }
    }
}
