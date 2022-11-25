using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectN.Models
{
    public class FunkoValue
    {
        [Key]
        public int Estvalue { get; set; }

        public int RetailPrice { get; set; }

        public bool Isvaulted { get; set; }

        public int RecentSold { get; set; }
    }
}
