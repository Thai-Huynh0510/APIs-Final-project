using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectN.Models

{
    public class Funkopop
    {
        [Key]
        public int FunkoId { get; set; }
        public string? FunkoName { get; set; }

        public string? Series { get; set; }

        public int ProductYear { get; set; }

        public FunkoValue? EstValue { get; set; }
    }
}
